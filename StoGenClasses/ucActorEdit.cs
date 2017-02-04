using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace StoGen.Classes
{
    public partial class ucActorEdit : UserControl
    {
        public ucActorEdit()
        {
            InitializeComponent();

            Array a = Enum.GetValues(typeof(CountryEnum));
            foreach (int item in a)
            {
                this.cbCountry.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(CountryEnum),item), (CountryEnum)item,-1));
            }
            this.cbCountry.SelectedIndex = 0;

            a = Enum.GetValues(typeof(GenderEnum));
            foreach (int item in a)
            {
                this.cbGender.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(GenderEnum), item), (GenderEnum)item, -1));
            }
            this.cbGender.SelectedIndex = 0;


            a = Enum.GetValues(typeof(RaceEnum));
            foreach (int item in a)
            {
                this.cbRace.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(RaceEnum), item), (RaceEnum)item, -1));
            }
            this.cbRace.SelectedIndex = 0;

            a = Enum.GetValues(typeof(FaceTypeEnum));
            foreach (int item in a)
            {
                this.cFaceType.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(FaceTypeEnum), item), (FaceTypeEnum)item, -1));
            }
            this.cFaceType.SelectedIndex = 0;

            a = Enum.GetValues(typeof(BodyTypeEnum));
            foreach (int item in a)
            {
                this.cbBodyType.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(BodyTypeEnum), item), (BodyTypeEnum)item, -1));
            }
            this.cbBodyType.SelectedIndex = 0;


            a = Enum.GetValues(typeof(BodyHeightEnum));
            foreach (int item in a)
            {
                this.cbBodyHeight.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(BodyHeightEnum), item), (BodyHeightEnum)item, -1));
            }
            this.cbBodyHeight.SelectedIndex = 0;

            a = Enum.GetValues(typeof(BodyShouldersEnum));
            foreach (int item in a)
            {
                this.cbBodyShoulders.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(BodyShouldersEnum), item), (BodyShouldersEnum)item, -1));
            }
            this.cbBodyShoulders.SelectedIndex = 0;

            a = Enum.GetValues(typeof(BodyBreastEnum));
            foreach (int item in a)
            {
                this.cbBreast.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(BodyBreastEnum), item), (BodyBreastEnum)item, -1));
            }
            this.cbBreast.SelectedIndex = 0;

            a = Enum.GetValues(typeof(BodyWaistEnum));
            foreach (int item in a)
            {
                this.cbWaist.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(BodyWaistEnum), item), (BodyWaistEnum)item, -1));
            }
            this.cbWaist.SelectedIndex = 0;

            a = Enum.GetValues(typeof(BodyHipsEnum));
            foreach (int item in a)
            {
                this.cbHips.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(BodyHipsEnum), item), (BodyHipsEnum)item, -1));
            }
            this.cbHips.SelectedIndex = 0;



            a = Enum.GetValues(typeof(ActivityTypeEnum));
            foreach (int item in a)
            {
                this.cbActivity.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(ActivityTypeEnum), item), (ActivityTypeEnum)item, -1));
            }
            this.cbActivity.SelectedIndex = 0;

            
        }
        SgActor CurrentActor;
        public void SetActor(SgActor m)
        {
            CurrentActor = m;
            seId.Text = $"{m.Id}";
            teName.Text = m.Name;
            teAliace.Text = m.Aliace;
            seYear.Value = m.BornYear;
            seScore.Value = m.Score;
            cbActivity.EditValue = m.ActivityType;
            cbBodyType.EditValue = m.BodyType;
            cbCountry.EditValue = m.BornCountry;
            cbGender.EditValue = m.Gender;
            cbRace.EditValue = m.Race;
            cFaceType.EditValue = m.FaceType;
            meDescrShort.Text = m.DescriptionShort;
            meDescrFull.Text = m.DescriptionLong;
            DS_Image.DataSource = m.PicList;

            cbBodyHeight.EditValue = m.Bd_Height;
            cbBodyShoulders.EditValue = m.Bd_Shoulders;
            cbBreast.EditValue = m.Bd_Breasts;
            cbWaist.EditValue = m.Bd_Waist;
            cbHips.EditValue = m.Bd_Hips;

        }
        public SgActor GetActor()
        {
            CurrentActor.Name = teName.Text.Trim();
            CurrentActor.Aliace = teAliace.Text.Trim();
            CurrentActor.BornYear = (int)seYear.Value;
            CurrentActor.Score = (int)seScore.Value;
            CurrentActor.ActivityType = (ActivityTypeEnum)cbActivity.EditValue;
            CurrentActor.BodyType = (BodyTypeEnum)cbBodyType.EditValue;
            CurrentActor.BornCountry = (CountryEnum)cbCountry.EditValue;
            CurrentActor.Gender = (GenderEnum)cbGender.EditValue;
            CurrentActor.Race = (RaceEnum)cbRace.EditValue;
            CurrentActor.FaceType = (FaceTypeEnum)cFaceType.EditValue;
            CurrentActor.DescriptionShort = meDescrShort.Text;
            CurrentActor.DescriptionLong = meDescrFull.Text;

            CurrentActor.Bd_Height = (BodyHeightEnum)cbBodyHeight.EditValue;
            CurrentActor.Bd_Shoulders = (BodyShouldersEnum)cbBodyShoulders.EditValue;
            CurrentActor.Bd_Breasts = (BodyBreastEnum)cbBreast.EditValue;
            CurrentActor.Bd_Waist = (BodyWaistEnum)cbWaist.EditValue;
            CurrentActor.Bd_Hips = (BodyHipsEnum)cbHips.EditValue;

            return this.CurrentActor;
        }

        private void DS_Image_CurrentChanged(object sender, EventArgs e)
        {
            if (this.DS_Image.Current != null)
            {
                this.Pbox.Image = ((SgPicture)this.DS_Image.Current).Picture;
            }
        }
    }
}
