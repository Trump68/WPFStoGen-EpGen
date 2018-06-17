using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Mathematics.Interop;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using System.Runtime.Serialization.Formatters.Binary;

using System.Windows.Forms;
using System.Runtime.Serialization;

namespace hkxPoser
{
    class Viewer : IDisposable
    {
        Control control;

        SharpDX.Direct3D11.Device device;
        SwapChain swapChain;

        SharpDX.Direct2D1.Factory d2dFactory;
        SharpDX.DirectWrite.Factory dwriteFactory;

        RenderTarget renderTarget;

        SolidColorBrush textBrush;
        SolidColorBrush boneLineBrush;
        SolidColorBrush boneLineBrush2;
        SolidColorBrush selectedBoneLineBrush;
        SolidColorBrush xaxisBrush;
        SolidColorBrush yaxisBrush;
        SolidColorBrush zaxisBrush;

        TextFormat textFormat;

        Color textColor = Color.Black;
        Color boneLineColor = new ColorBGRA(100, 100, 230, 255);              
        Color boneLineColor2 = Color.Lavender;
        Color selectedBoneLineColor = new ColorBGRA(255, 0, 0, 255);
        Color xaxisColor = new ColorBGRA(255, 0, 0, 255);
        Color yaxisColor = new ColorBGRA(0, 255, 0, 255);
        Color zaxisColor = new ColorBGRA(0, 0, 255, 255);

        int CreateDeviceIndependentResources()
        {
            d2dFactory = new SharpDX.Direct2D1.Factory();
            dwriteFactory = new SharpDX.DirectWrite.Factory();

            return 0;
        }

        int CreateDeviceResources(ref Size2 size)
        {
            if (renderTarget == null)
            {
                using (Surface sf = swapChain.GetBackBuffer<Surface>(0))
                {
                    renderTarget = new RenderTarget(d2dFactory, sf, new RenderTargetProperties(new PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)));
                }

                textBrush = new SolidColorBrush(renderTarget, textColor);
                boneLineBrush = new SolidColorBrush(renderTarget, boneLineColor);
                boneLineBrush2 = new SolidColorBrush(renderTarget, boneLineColor2);
                selectedBoneLineBrush = new SolidColorBrush(renderTarget, selectedBoneLineColor);
                xaxisBrush = new SolidColorBrush(renderTarget, xaxisColor);
                yaxisBrush = new SolidColorBrush(renderTarget, yaxisColor);
                zaxisBrush = new SolidColorBrush(renderTarget, zaxisColor);

                textFormat = new TextFormat(dwriteFactory, "Verdana", FontWeight.Bold, FontStyle.Normal, 14.0f);
            }
            return 0;
        }

        int DiscardDeviceResources()
        {
            if (renderTarget != null)
            {
                textFormat?.Dispose();

                zaxisBrush?.Dispose();
                yaxisBrush?.Dispose();
                xaxisBrush?.Dispose();
                selectedBoneLineBrush?.Dispose();
                boneLineBrush?.Dispose();
                boneLineBrush2?.Dispose();
                textBrush?.Dispose();

                renderTarget.Dispose();
                renderTarget = null;
            }
            return 0;
        }

        /// <summary>
        /// マウスポイントしているスクリーン座標
        /// </summary>
        protected Point lastScreenPoint = Point.Zero;

        /// マウスボタンを押したときに実行するハンドラ
        protected void form_OnMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectBone();
                    break;
            }

            lastScreenPoint.X = e.X;
            lastScreenPoint.Y = e.Y;
        }

        /// マウスを移動したときに実行するハンドラ
        protected void form_OnMouseMove(object sender, MouseEventArgs e)
        {
            int dx = e.X - lastScreenPoint.X;
            int dy = e.Y - lastScreenPoint.Y;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    camera.Move(dx, -dy, 0.0f);
                    break;
                case MouseButtons.Middle:
                    camera.MoveView(-dx * 0.3125f, dy * 0.3125f);
                    break;
                case MouseButtons.Right:
                    camera.Move(0.0f, 0.0f, -dy * 0.3125f);
                    break;
            }

            lastScreenPoint.X = e.X;
            lastScreenPoint.Y = e.Y;
        }

        public void AttachMouseEventHandler(Control control)
        {
            control.MouseDown += new MouseEventHandler(form_OnMouseDown);
            control.MouseMove += new MouseEventHandler(form_OnMouseMove);
        }

        public void DetachMouseEventHandler(Control control)
        {
            control.MouseMove -= new MouseEventHandler(form_OnMouseMove);
            control.MouseDown -= new MouseEventHandler(form_OnMouseDown);
        }

        Viewport viewport;

        Matrix world;
        Matrix view;
        Matrix proj;
        Matrix wvp;

        hkaSkeleton skeleton;
        hkaSkeleton skeleton2;
        public hkaAnimation anim;

        public event EventHandler LoadAnimationEvent;

        void CreateViewport(ref System.Drawing.Size clientSize)
        {
            viewport = new Viewport(0, 0, clientSize.Width, clientSize.Height, 0.0f, 1.0f);

            Matrix.PerspectiveFovRH(
                    (float)(Math.PI / 6.0),
                    (float)viewport.Width / (float)viewport.Height,
                    1.0f,
                    500.0f,
                    out proj);
        }

        protected void form_Resize(object sender, EventArgs e)
        {
            DiscardDeviceResources();

            SwapChainDescription desc = swapChain.Description;
            System.Drawing.Size clientSize = control.ClientSize;

            swapChain.ResizeBuffers(desc.BufferCount, clientSize.Width, clientSize.Height, desc.ModeDescription.Format, desc.Flags);

            CreateViewport(ref clientSize);
        }

        public bool InitializeGraphics(Control control)
        {
            this.control = control;

            AttachMouseEventHandler(control);
            control.Resize += new System.EventHandler(form_Resize);

            System.Drawing.Size clientSize = control.ClientSize;

            // SwapChain description
            var desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(clientSize.Width, clientSize.Height, new Rational(60, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputHandle = control.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            // Create Device and SwapChain
            SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, new SharpDX.Direct3D.FeatureLevel[] { SharpDX.Direct3D.FeatureLevel.Level_10_0 }, desc, out device, out swapChain);
            CreateViewport(ref clientSize);

            world = Matrix.Identity;

            string skel_file = Path.Combine(Application.StartupPath, @"resources\skeleton-bbp.bin");
            skeleton = new hkaSkeleton();
            skeleton.Load(skel_file);


            string anim_file = Path.Combine(Application.StartupPath, @"resources\idle.bin");
            anim = new hkaAnimation();
            if (anim.Load(anim_file,1))
            {
                LoadAnimationSuccessful(Path.ChangeExtension(anim_file, ".hkx"),1);
            }
            CreateDeviceIndependentResources();

            return true;
        }
        public void LoadSecondSkeleton()
        {
            if (skeleton2 != null) return;
            string skel_file = Path.Combine(Application.StartupPath, @"resources\skeleton-bbp.bin");
            // 2nd skeleton
            skeleton2 = new hkaSkeleton();
            skeleton2.Load(skel_file);
            string anim_file = Path.Combine(Application.StartupPath, @"resources\idle.bin");
            if (anim.Load(anim_file, 2))
            {
                LoadAnimationSuccessful(Path.ChangeExtension(anim_file, ".hkx"), 2);
            }
        }

        internal void SetRotationBone(float x, float y, float z, float w)
        {
            if (this.selected_bone == null) return;
            this.selected_bone.patch.rotation.Z = z;
        }

        public void AssignAnimationPose(int pose_i, int selNum)
        {            
            var skelRef = skeleton;
            pose_i %= anim.numOriginalFrames;
            hkaPose pose = anim.pose[pose_i];
            if (selNum == 2)
            {
                if (skeleton2 == null)
                    return;
                skelRef = skeleton2;
                pose_i %= anim.numOriginalFrames2;
                pose = anim.pose2[pose_i];
            }

            int nbones = System.Math.Min(skelRef.bones.Length, pose.transforms.Length);
            for (int i = 0; i < nbones; i++)
            {
                if (skelRef.bones[i].name == "NPC L PreBreast")
                {
                    bool ok = true;
                }
                skelRef.bones[i].local = pose.transforms[i];
            }            
        }

        public void ApplyPoseData(hkaPoseData data, int pose_i, bool all, bool fromRoot)
        {
            hkaPose pose = anim.pose[pose_i];
            foreach (var item in data.transformList)
            {
                if (!fromRoot && item.Key.Contains("NPC Root")) continue;
                int index = skeleton.FindBoneIndex(item.Key);
                if (index > -1)
                {
                    if (anim.pose[pose_i].transforms.Length <= index) continue;
                    anim.pose[pose_i].transforms[index] = item.Value;
                    if (all)
                    {
                        for (int i = pose_i; i < anim.pose.Length; i++)
                        {
                            anim.pose[i].transforms[index] = item.Value;
                        }
                    }
                    skeleton.bones[index].local = anim.pose[pose_i].transforms[index];
                }
            }
            AssignAnimationPose(pose_i,1);       
        }

        public void ApplyPoseData2(hkaPoseData data, int pose_i, bool all, bool fromRoot)
        {
            hkaPose pose = anim.pose[pose_i];
            foreach (var item in data.transformList)
            {
                if (!fromRoot && item.Key.Contains("NPC Root")) continue;
                int index = skeleton.FindBoneIndex(item.Key);
                if (index > -1)
                {
                    skeleton.bones[index].patch.rotation = getQuaternionDff(skeleton.bones[index].local.rotation, item.Value.rotation);
                    skeleton.bones[index].patch.translation.X = item.Value.translation.X - skeleton.bones[index].local.translation.X;
                    skeleton.bones[index].patch.translation.Z = item.Value.translation.Z - skeleton.bones[index].local.translation.Z;
                    skeleton.bones[index].patch.translation.Y = item.Value.translation.Y - skeleton.bones[index].local.translation.Y;
                }
            }
        }

        Quaternion getQuaternionDff(Quaternion a, Quaternion b)
        {
            Quaternion inv = a;
            inv.Invert();
            return inv * b;
        }

    public void SerializatePose(int pose_i,string findname)
        {             

            BinaryFormatter bf = new BinaryFormatter();
            // 1. Construct a SurrogateSelector object
            SurrogateSelector ss = new SurrogateSelector();

            Vector3SerializationSurrogate v3ss = new Vector3SerializationSurrogate();
            ss.AddSurrogate(typeof(Vector3),
                            new StreamingContext(StreamingContextStates.All),
                            v3ss);

            QuarteronSerializationSurrogate qss = new QuarteronSerializationSurrogate();
            ss.AddSurrogate(typeof(Quaternion),
                            new StreamingContext(StreamingContextStates.All),
                            qss);

            // 2. Have the formatter use our surrogate selector
            bf.SurrogateSelector = ss;

            ApplyPosePatchForcadre(anim.pose[current_pose_i], true);
            AssignAnimationPose(pose_i,1);
            hkaPoseData data = GetBoneData(findname);
            FileStream stream = File.Create(@"c:\temp\savedpose.tmp");
            bf.Serialize(stream, data);
            stream.Close();
        }
        private hkaPoseData GetBoneData(string findname, bool includehide = true)
        {
            if (string.IsNullOrEmpty(findname))
            {
                findname = skeleton.bones[0].name;
            }
            hkaPoseData data = new hkaPoseData();
            hkaBone root_bone = skeleton.FindBone(findname.ToLower(), includehide);
            if (root_bone != null)
            {
                getBoneData(data, root_bone);
            }
            return data;
        }

        private void getBoneData(hkaPoseData data, hkaBone bone)
        {
            if (data.transformList == null)
                data.transformList = new Dictionary<string, Transform>();

            if (!data.transformList.ContainsKey(bone.name))
            {

                if (!bone.hide)
                {
                    data.transformList.Add(bone.name, bone.local);                    
                }
            }
            foreach (hkaBone b in bone.children)
            {
                getBoneData(data, b);
            }
        }

        public void DeserializatePose(int pose_i, bool all, bool fromRoot)
        {
            var posedata = DeserializePoseData();
            ApplyPoseData(posedata, pose_i, all, fromRoot);
        }
        public void DeserializatePose2(int pose_i, bool fromRoot)
        {
            ApplyPoseData2(DeserializePoseData(), pose_i, false, fromRoot);
        }
        public hkaPoseData DeserializePoseData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            // 1. Construct a SurrogateSelector object
            SurrogateSelector ss = new SurrogateSelector();

            Vector3SerializationSurrogate v3ss = new Vector3SerializationSurrogate();
            ss.AddSurrogate(typeof(Vector3),
                            new StreamingContext(StreamingContextStates.All),
                            v3ss);

            QuarteronSerializationSurrogate qss = new QuarteronSerializationSurrogate();
            ss.AddSurrogate(typeof(Quaternion),
                            new StreamingContext(StreamingContextStates.All),
                            qss);

            // 2. Have the formatter use our surrogate selector
            bf.SurrogateSelector = ss;

            FileStream stream = File.OpenRead(@"c:\temp\savedpose.tmp");
            var v = bf.Deserialize(stream) as hkaPoseData;
            stream.Close();
            return v;
        }
        bool wasExpanded = false;
        public void ApplyPatchToAnimation(bool clearpatch)
        {
            if (wasExpanded) return;
            foreach (hkaPose pose in anim.pose)
            {
                ApplyPosePatchForcadre(pose, clearpatch);
            }
            ClearPatch();
            ClearCommands();
        }
        public void ApplyPosePatchForcadre(hkaPose pose, bool clearpatch)
        {       
            if (skeleton.referencePose.Length > pose.transforms.Length)
            {
                var ss = pose.transforms.ToList();
                while (skeleton.referencePose.Length > ss.Count)
                {
                    ss.Add(skeleton.referencePose[ss.Count]);
                }
                pose.transforms = ss.ToArray();
            }
            int nbones = System.Math.Min(skeleton.bones.Length, pose.transforms.Length);
            for (int i = 0; i < nbones; i++)
            {
                if (skeleton.bones[i].name == "NPC L PreBreast")
                {
                    bool ok = true;
                }                
                pose.transforms[i] *= skeleton.bones[i].patch;
                if (clearpatch)
                  skeleton.bones[i].patch = new Transform();
            }
            
        }

        public void ApplyPatchForcadre(int num)
        {
            var pose = anim.pose[num];
            ApplyPosePatchForcadre(pose,true);
            AssignAnimationPose(num,1);
        }

        public void ClearPatch()
        {
            foreach (hkaBone bone in skeleton.bones)
            {
                bone.patch = new Transform();
            }
        }

        public static string EscapeFileName(string file)
        {
            return '"' + file + '"';
        }

        public static string CreateTempFileName(string file)
        {
            string basename = Path.GetFileNameWithoutExtension(file);
            return Path.Combine(Application.StartupPath, @"tmp\" + basename + ".bin");
        }

        public void LoadAnimation(string source_file, int skelNum)
        {
            string file = CreateTempFileName(source_file);

            ProcessStartInfo info = new ProcessStartInfo(
                    Path.Combine(Application.StartupPath, @"bin\hkdump-bin.exe"),
                    EscapeFileName(source_file) + " -o " + EscapeFileName(file));
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;

            Process process = Process.Start(info);
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
            if (process.ExitCode == 0) // successful
            {
                if (anim.Load(file, skelNum))
                {
                    LoadAnimationSuccessful(source_file, skelNum);
                }
            }
        }

        string anim_filename = "idle.hkx";

        void LoadAnimationSuccessful(string source_file, int skelNum)
        {
            this.anim_filename = Path.GetFileName(source_file);

            if (LoadAnimationEvent != null)
                LoadAnimationEvent(this, EventArgs.Empty);

            AssignAnimationPose(0, skelNum);
        }

        public void SaveAnimation(string dest_file, int speed)
        {
            string file = CreateTempFileName(dest_file);

            ApplyPatchToAnimation(false);

            //anim.numOriginalFrames = 1;
            //anim.duration = 1.0f/30.0f;
            anim.Save(file, speed);

            ProcessStartInfo info = new ProcessStartInfo(
                    Path.Combine(Application.StartupPath, @"bin\hkconv.exe"),
                    EscapeFileName(file) + " -o " + EscapeFileName(dest_file));
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;

            Process process = Process.Start(info);
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
            SetCurrentPose(0);
        }

        SimpleCamera camera = new SimpleCamera();

        public int current_pose_i = 0;

        public int GetNumFrames()
        {
            return anim.numOriginalFrames;
        }

        public void SetCurrentPose(int pose_i)
        {
            current_pose_i = pose_i;
            AssignAnimationPose(pose_i, 1);
            AssignAnimationPose(pose_i, 2);
        }

        public void Update()
        {
            camera.Update();
            view = camera.ViewMatrix;
            wvp = world * view * proj;

            // run animation

            if (isRunAnimation)
            {
                //current_pose_i = anim.pose
                AssignAnimationPose(current_pose_i,1);
                current_pose_i++;
                current_pose_i %= anim.numOriginalFrames;
            }
            
        }
        public bool isRunAnimation = false;

        public void Render()
        {
            Size2 size = new Size2(viewport.Width, viewport.Height);

            CreateDeviceResources(ref size);

            renderTarget.BeginDraw();
            renderTarget.Clear(new Color(192, 192, 192, 255));

            DrawCenterAxis();

            DrawBoneTree(1);
            if (skeleton2 != null)  DrawBoneTree(2);
            DrawSelectedBone();

            DrawText(ref size);

            try
            {
                renderTarget.EndDraw();
            }
            catch (SharpDXException ex) when ((uint)ex.HResult == 0x8899000C) // D2DERR_RECREATE_TARGET
            {
                // device has been lost!
                DiscardDeviceResources();
            }

            swapChain.Present(0, PresentFlags.None);
        }

        void DrawText(ref Size2 size)
        {
            renderTarget.DrawText(string.Format("File: {0}", this.anim_filename), textFormat, new RectangleF(12, size.Height-12-45-20, size.Width-24, 20), textBrush);
        }

        void DrawLine(Vector3 p0, Vector3 p1, Brush brush)
        {
            renderTarget.DrawLine(new Vector2(p0.X, p0.Y), new Vector2(p1.X, p1.Y), brush);
        }

        void DrawCenterAxis()
        {
            Vector3 center = Vector3.Zero;
            Vector3 xaxis = new Vector3(5, 0, 0);
            Vector3 yaxis = new Vector3(0, 5, 0);
            Vector3 zaxis = new Vector3(0, 0, 5);

            Vector3 scr_center = WorldToScreen(center);
            Vector3 scr_xaxis = WorldToScreen(xaxis);
            Vector3 scr_yaxis = WorldToScreen(yaxis);
            Vector3 scr_zaxis = WorldToScreen(zaxis);

            DrawLine(scr_center, scr_xaxis, xaxisBrush);
            DrawLine(scr_center, scr_yaxis, yaxisBrush);
            DrawLine(scr_center, scr_zaxis, zaxisBrush);
        }

        /// <summary>
        /// viewport行列を作成します。
        /// </summary>
        /// <param name="viewport">viewport</param>
        /// <returns>viewport行列</returns>
        public static Matrix CreateViewportMatrix(Viewport viewport)
        {
            Matrix m = Matrix.Identity;
            m.M11 = (float)viewport.Width / 2;
            m.M22 = -1.0f * (float)viewport.Height / 2;
            m.M33 = (float)viewport.MaxDepth - (float)viewport.MinDepth;
            m.M41 = (float)(viewport.X + viewport.Width / 2);
            m.M42 = (float)(viewport.Y + viewport.Height / 2);
            m.M43 = viewport.MinDepth;
            return m;
        }

        /// ワールド座標をスクリーン位置へ変換します。
        public static Vector3 WorldToScreen(Vector3 v, Viewport viewport, Matrix view, Matrix proj)
        {
            return Vector3.TransformCoordinate(v, view * proj * CreateViewportMatrix(viewport));
        }

        /// ワールド座標をスクリーン位置へ変換します。
        public Vector3 WorldToScreen(Vector3 v)
        {
            return WorldToScreen(v, viewport, view, proj);
        }

        Vector3 GetBonePositionOnScreen(hkaBone bone)
        {
            Transform t = bone.GetWorldCoordinate();
            return WorldToScreen(t.translation);
        }

        public void DrawBoneTree(int skelNum)
        {
            var skelRef = skeleton;
            var brushRef = boneLineBrush;
            if (skelNum == 2)
            {
                skelRef = skeleton2;
                brushRef = boneLineBrush2;
            }
            foreach (hkaBone bone in skelRef.bones)
            {
                if (bone.hide)
                    continue;
                if (bone.idx == 99)
                {
                    bool ok = true;
                }

                Vector3 p0 = GetBonePositionOnScreen(bone);
                p0.Z = 0.0f;

                if (bone.parent != null && !bone.parent.hide)
                {
                    Vector3 p1 = GetBonePositionOnScreen(bone.parent);
                    p1.Z = 0.0f;

                    Vector3 pd = p0 - p1;
                    float len = pd.Length();
                    float scale = 4.0f / len;
                    Vector2 p3 = new Vector2(p1.X + pd.Y * scale, p1.Y - pd.X * scale);
                    Vector2 p4 = new Vector2(p1.X - pd.Y * scale, p1.Y + pd.X * scale);

                    RawVector2[] vertices = new RawVector2[3];
                    vertices[0] = new RawVector2(p3.X, p3.Y);
                    vertices[1] = new RawVector2(p0.X, p0.Y);
                    vertices[2] = new RawVector2(p4.X, p4.Y);
                    renderTarget.DrawLine(vertices[0], vertices[1], brushRef);
                    renderTarget.DrawLine(vertices[1], vertices[2], brushRef);
                }
            }

            foreach (hkaBone bone in skelRef.bones)
            {
                if (bone.hide)
                    continue;

                Vector3 p0 = GetBonePositionOnScreen(bone);
                p0.Z = 0.0f;

                renderTarget.DrawEllipse(new Ellipse(new Vector2(p0.X, p0.Y), 4, 4), brushRef);
                renderTarget.FillEllipse(new Ellipse(new Vector2(p0.X, p0.Y), 2, 2), brushRef);
            }

            //DrawBoneAxis(bone);
        }

        /// 選択boneを描画する。
        void DrawSelectedBone()
        {
            if (selected_bone == null)
                return;

            Vector3 p1 = GetBonePositionOnScreen(selected_bone);
            p1.Z = 0.0f;

            if (selected_bone.children.Count != 0)
            {
                hkaBone bone = selected_bone.children[0];
                Vector3 p0 = GetBonePositionOnScreen(bone);
                p0.Z = 0.0f;

                Vector3 pd = p0 - p1;
                float len = pd.Length();
                float scale = 4.0f / len;
                Vector2 p3 = new Vector2(p1.X + pd.Y * scale, p1.Y - pd.X * scale);
                Vector2 p4 = new Vector2(p1.X - pd.Y * scale, p1.Y + pd.X * scale);

                RawVector2[] vertices = new RawVector2[3];
                vertices[0] = new RawVector2(p3.X, p3.Y);
                vertices[1] = new RawVector2(p0.X, p0.Y);
                vertices[2] = new RawVector2(p4.X, p4.Y);
                renderTarget.DrawLine(vertices[0], vertices[1], selectedBoneLineBrush);
                renderTarget.DrawLine(vertices[1], vertices[2], selectedBoneLineBrush);
            }

            DrawBoneAxis(selected_bone);

            renderTarget.DrawEllipse(new Ellipse(new Vector2(p1.X, p1.Y), 4, 4), selectedBoneLineBrush);
            renderTarget.FillEllipse(new Ellipse(new Vector2(p1.X, p1.Y), 2, 2), selectedBoneLineBrush);
        }

        void DrawBoneAxis(hkaBone bone)
        {
            Transform t = bone.GetWorldCoordinate();

            Matrix3x3 rotation;
            Matrix3x3.RotationQuaternion(ref t.rotation, out rotation);
            Vector3 xvec = rotation.Row1 * 5.0f;
            Vector3 yvec = rotation.Row2 * 5.0f;
            Vector3 zvec = rotation.Row3 * 5.0f;
            Vector3 location = t.translation;

            Vector3 xaxis = location + xvec;
            Vector3 yaxis = location + yvec;
            Vector3 zaxis = location + zvec;

            Vector3 scr_location = WorldToScreen(location);
            Vector3 scr_xaxis = WorldToScreen(xaxis);
            Vector3 scr_yaxis = WorldToScreen(yaxis);
            Vector3 scr_zaxis = WorldToScreen(zaxis);

            DrawLine(scr_location, scr_xaxis, xaxisBrush);
            DrawLine(scr_location, scr_yaxis, yaxisBrush);
            DrawLine(scr_location, scr_zaxis, zaxisBrush);
        }

        public hkaBone selected_bone = null;

        /// boneを選択します。
        /// returns: boneを見つけたかどうか
        public bool SelectBone()
        {
            bool found = false;

            //スクリーン座標からboneを見つけます。
            //衝突する頂点の中で最も近い位置にあるboneを返します。

            float x = lastScreenPoint.X;
            float y = lastScreenPoint.Y;

            int width = 5;//頂点ハンドルの幅
            float min_z = 1e12f;

            hkaBone found_bone = null;

            foreach (hkaBone bone in skeleton.bones)
            {
                if (bone.hide)
                    continue;

                Vector3 p2 = GetBonePositionOnScreen(bone);
                if (p2.X - width <= x && x <= p2.X + width && p2.Y - width <= y && y <= p2.Y + width)
                {
                    if (p2.Z < min_z)
                    {
                        min_z = p2.Z;
                        found = true;
                        found_bone = bone;
                    }
                }
            }

            if (found)
            {
                selected_bone = found_bone;
                Console.WriteLine("Select Bone: {0}", selected_bone.name);
                this.InputBox.Text = selected_bone.name;
                this.RotationsText.Text = $"{selected_bone.local.rotation.X},{selected_bone.local.rotation.Y},{selected_bone.local.rotation.Z},{selected_bone.local.rotation.W}";

                camera.Center = selected_bone.GetWorldCoordinate().translation;
                camera.UpdateTranslation();
            }
            return found;
        }

        public bool FindBoneByName(string findname)
        {
            bool found = false;

        
            hkaBone found_bone = null;

            foreach (hkaBone bone in skeleton.bones)
            {
                if (bone.hide)
                    continue;

                
                if (bone.name.ToLower() == findname)
                {
                        found = true;
                        found_bone = bone;
                }
            }

            if (found)
            {
                selected_bone = found_bone;
                Console.WriteLine("Select Bone: {0}", selected_bone.name);

                camera.Center = selected_bone.GetWorldCoordinate().translation;
                camera.UpdateTranslation();
            }
            return found;
        }


        /// 操作リスト
        public List<ICommand> commands = new List<ICommand>();
        int command_id = 0;

        /// 指定操作を実行します。
        public void Execute(ICommand command)
        {
            if (command.Execute())
            {
                if (command_id == commands.Count)
                    commands.Add(command);
                else
                    commands[command_id] = command;
                command_id++;
            }
        }

        /// 操作を消去します。
        public void ClearCommands()
        {
            commands.Clear();
            command_id = 0;
        }

        /// ひとつ前の操作による変更を元に戻せるか。
        public bool CanUndo()
        {
            return (command_id > 0);
        }

        /// ひとつ前の操作による変更を元に戻します。
        public void Undo()
        {
            if (!CanUndo())
                return;

            command_id--;
            Undo(commands[command_id]);
        }

        /// 指定操作による変更を元に戻します。
        public void Undo(ICommand command)
        {
            command.Undo();
        }

        /// ひとつ前の操作による変更をやり直せるか。
        public bool CanRedo()
        {
            return (command_id < commands.Count);
        }

        /// ひとつ前の操作による変更をやり直します。
        public void Redo()
        {
            if (!CanRedo())
                return;

            Redo(commands[command_id]);
            command_id++;
        }

        /// 指定操作による変更をやり直します。
        public void Redo(ICommand command)
        {
            command.Redo();
        }

        BoneCommand bone_command = null;

        public TextBox InputBox { get; internal set; }
        public TextBox RotationsText { get; internal set; }

        /// bone操作を開始します。
        public void BeginBoneCommand()
        {
            if (selected_bone == null)
                return;

            bone_command = new BoneCommand(selected_bone);
        }

        /// boneを操作中であるか。
        public bool HasBoneCommand()
        {
            return bone_command != null;
        }

        /// bone操作を終了します。
        public void EndBoneCommand()
        {
            if (bone_command != null)
                Execute(bone_command);

            bone_command = null;
        }

        /// 選択boneを指定軸方向に移動します。
        public void TranslateAxis(int dx, int dy, Vector3 axis)
        {
            hkaBone bone = selected_bone;

            if (bone == null)
                return;

            axis = Vector3.Transform(axis, bone.local.rotation * bone.patch.rotation);

            float len = dx * 0.0125f;
            bone.patch.translation += axis * len;
        }

        /// 選択boneを指定軸中心に回転します。
        public void RotateAxis(int dx, int dy, Vector3 axis)
        {
            hkaBone bone = selected_bone;

            if (bone == null)
                return;

            float angle = dx * 0.005f;
            bone.patch.rotation *= Quaternion.RotationAxis(axis, angle);
        }

        public void Dispose()
        {
            /*
            dot_texture?.Dispose();
            sprite?.Dispose();
            */
            swapChain?.Dispose();
            device?.Dispose();
        }


        /////////////////////// INTERPOLATION ///////////////////////

        public void Interpolate(int start,int pos1, int pos2, int end, bool rootOnly = false)
        {
            if (pos1 < start) pos1 = start;
            if (pos2 < pos1)  pos2 = pos1;
            if (end < pos2) end = pos2;

            hkaPose poseStart = this.anim.pose[start];
            hkaPose poseEnd = this.anim.pose[end];
            hkaPose pose1 = this.anim.pose[pos1];
            hkaPose pose2 = this.anim.pose[pos2];

            hkaPose currPose = null;
            for (int i = start+1; i < end ; i++)
            {
               
                currPose = this.anim.pose[i];

                float weight = Weight(start, end, i);

                interpolatePose(poseStart, pose1, pose2, poseEnd, currPose, weight, rootOnly);
            }

        }
        private void interpolatePose(hkaPose poseStart, hkaPose pose1, hkaPose pose2, hkaPose poseEnd, hkaPose pose, float weight, bool rootOnly = false)
        {
            string tofind = null;
            if (selected_bone != null)
                tofind = selected_bone.name;

            hkaPoseData data = GetBoneData(tofind, true);
            foreach (var item in data.transformList)
            {
                if (rootOnly && !item.Key.Contains("NPC Root")) continue;
                

                int index = skeleton.FindBoneIndex(item.Key);
                if (index > -1)
                {
                    if (pose.transforms.Length <= index) continue;

                    if (rootOnly)
                    {
                        //var vec = 
                        //Vector3.Lerp(
                        //   poseStart.transforms[index].rotation.Axis,
                        //   poseEnd.transforms[index].rotation.Axis,
                        //   weight);
                        //pose.transforms[index].rotation = new Quaternion(vec, pose.transforms[index].rotation.Angle);
                        
                    }
                    else
                    {
                        pose.transforms[index].rotation =
                        Quaternion.Slerp(
                            poseStart.transforms[index].rotation,
                            poseEnd.transforms[index].rotation,
                            weight);
                        pose.transforms[index].translation =
                        Vector3.Lerp(
                            poseStart.transforms[index].translation,
                            poseEnd.transforms[index].translation,
                            weight);
                    }
                }
            }


            //if (tofind == null)
            //{
            //    for (int i = 0; i < pose.transforms.Length; i++)
            //    {
            //        pose.transforms[i].rotation =
            //            Quaternion.Slerp(
            //                poseStart.transforms[i].rotation,
            //                //pose1.transforms[i].rotation,
            //                //pose2.transforms[i].rotation,
            //                poseEnd.transforms[i].rotation,
            //                weight);
            //        //skeleton.bones[i].local = pose.transforms[i];
            //    }
            //}
            //else
            //{
            //    pose.transforms[selected_bone.idx].rotation =
            //           Quaternion.Slerp(
            //               poseStart.transforms[selected_bone.idx].rotation,
            //               //pose1.transforms[i].rotation,
            //               //pose2.transforms[i].rotation,
            //               poseEnd.transforms[selected_bone.idx].rotation,
            //               weight);
            //}
        }


       private float Weight(float start, float end, int curr)
        {
            float result = 1;
            result = (curr - start) / (end - start);
            return result;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Clipping +++++++++++++++++++++++++++++++
        public void Clip(int numToClip, bool fromBegin)
        {
            if (!fromBegin)
            {
                anim.pose = anim.pose.Take(anim.pose.Length - numToClip).ToArray();
            }
            else
            {
                anim.pose = anim.pose.Skip(numToClip).ToArray();
            }
            anim.duration = anim.pose.Sum(x => x.time);
            anim.Refresh();
        }

        public void Add(int numToClip, bool fromBegin)
        {
            
            var animlist = anim.pose.ToList();
            if (!fromBegin)
            {
                for (int i = 0; i < numToClip; i++)
                {
                    var np = new hkaPose();
                    np.transforms = animlist.Last().transforms;
                    np.floats = animlist.Last().floats;
                    animlist.Add(np);
                }
            }
            else
            {

                for (int i = 0; i < numToClip; i++)
                {
                    var np = new hkaPose();
                    np.transforms = animlist.First().transforms;
                    np.floats = animlist.First().floats;
                    animlist.Insert(0, np);
                }
            }

            var step = 0.03333333F;
            int ist = 0;
            foreach (var item in animlist)
            {
                if (item != null)
                {
                    item.time = step * ist;
                    ist++;
                }
            }
            anim.pose = animlist.ToArray();
            if (anim.pose.Last() != null)
            {
                anim.duration = anim.pose.Last().time + step;
            }

            wasExpanded = true;
            anim.Refresh();
        }
    }
}
