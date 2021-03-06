# автоматическое объявление анимации
init python:
    #config.image_cache_size = 12
    config.image_cache_size_mb = 500
    config.cache_surfaces = True


    """
    описание функции Ani:
    автоматическое объявление картинки с анимацией,
    например есть кадры "images/neko%s.png",
    где %s - числа от 1 до 5, тогда объявляем анимацию так:
    image neko = Ani("neko", 5, 0.5, reverse = False)
    где:
    img_name - имя файла без номера (например, "neko")
    frames - количество кадров
    delay - пауза между кадрами в секундах
    loop - зациклить анимацию (по умолчанию включено)
    reverse - нужно ли проигрывание анимации в обратную сторону
    effect - эффект для смены кадров
    start - с какой цифры начинать отсчет кадров
    ext - расширение, если оно отлично от Null, то работаем с файлами,
    а не с displayable (уже объявленными или даже измененными изображениями)
    так же можно добавлять любые стандартные для изображений параметры, типа масштабирования или прозрачности:
    image neko = Ani("neko", 5, 0.5, zoom=2.0, alpha=0.75)
    """
    def Ani(img_name, frames, delay=.1, loop=True, reverse=False, forward=True, effect=None, start=1, ext="png", startpause= 0.0, reversepause= 0.0, **properties):
        if img_name:
            args = []
            isstarted = False
            if forward:
                for i in range(start, start + frames):
                    if ext is None:
                        args.append(renpy.easy.displayable(img_name + str(i)))
                    else:
                        args.append(renpy.display.im.image(img_name + str(i) + "." + ext))
                        # if (scale == 1.0)
                        #     args.append(renpy.display.im.image(img_name + str(i) + "." + ext))
                        # else:
                        #     args.append(im.FactorScale(img_name + str(i) + "." + ext, scale))

                    if (reverse or loop or (i < start + frames - 1)):
                        if (i == start):
                            args.append(delay + startpause)
                            isstarted = True
                        elif (i == start + frames - 1):
                            args.append(delay + reversepause)
                        else:
                            args.append(delay)
                        args.append(effect)

            if reverse: # обратная анимация, если нужна
                for i in range(start + frames - 2, start, -1):
                    if ext is None:
                        args.append(renpy.easy.displayable(img_name + str(i)))
                    else:
                        args.append(renpy.display.im.image(img_name + str(i) + "." + ext))
                        # if (scale == 1.0)
                        #     args.append(renpy.display.im.image(img_name + str(i) + "." + ext))
                        # else:
                        #     args.append(im.FactorScale(img_name + str(i) + "." + ext, scale))
                    if loop or (i > start + 1):
                        args.append(delay)
                        args.append(effect)

            return anim.TransitionAnimation(*args, **properties)
        return None


init:
    $ renpy.music.register_channel("bgs", "sfx", loop=True)
    $ diss = Dissolve(.01, alpha=True)
    image bg black      = "#000"
    image bg white      = "#FFF"
    image black         = "#000"
    image dancignHall = "Locations/DancingHall/index.jpg"
    #image im1 = Ani("Amra72ToiletTeasingStandBehind/01/m", 784, 0.02, False,False,True,effect=None, start=1)
    #image im2 = Ani("Amra72ToiletTeasingStandBehind/01/m", 184, 0.02, False,False,True,effect=None, start=501)
    image mp4 = Movie(fps=60, play = "x.mp4", mask = "y.mp4")

# The game starts here.
label main_menu:
    $ Start()

label start:

    scene black
    $ renpy.music.set_volume(0.5, 0, "music")
    $ renpy.music.set_volume(0.5, 0, "sound")
    $ renpy.music.set_volume(0.5, 0, "bgs")
    play music "BGM/yoru_kaisou.mp3" fadeout 1.0 fadein 1.0
    # play sound ["<silence 0.3>","SE/h_gisi.mp3","<silence .1>","SE/h_gisi2.mp3"] loop fadeout 1.0 fadein 1.0
    # play bgs ["<silence 2.4>","SE/H_Vo_CL_s_3.wav","SE/H_Vo_CL_s_5.mp3"] loop

    # $ dirname = "default"

    call Story02
    #call Story01
    #call Amra72DoubleBedCowgirl_02
    pause


    label BASE(labelname="default",cnt=1,rate=0.01,lp=True,bk=True,forv=True,st=1,sp=0.1,ep=0.1, xp = 0, yp = 0, scale = 1.0, effect=None):
        show movie:
            Ani(dirname +"/"+ labelname + "/m", cnt, rate, lp, bk, forv, effect, start=st, ext="jpg", startpause = sp, reversepause = ep)
            #xalign 0.5 yalign 0.3
            zoom scale
            xpos xp ypos yp
        pause
        pause 0.5
        hide movie
        return

    label BASEPNG(labelname="default",cnt=1,rate=0.01,lp=True,bk=True,forv=True,st=1,sp=0.1,ep=0.1, xp = 0, yp = 0, scale = 1.0, effect=None):
        show movie:
            Ani(dirname +"/"+ labelname + "/m", cnt, rate, lp, bk, forv, effect, start=st, ext="png", startpause = sp, reversepause = ep)
            #xalign 0.5 yalign 0.3
            zoom scale
            xpos xp ypos yp
        pause
        pause 0.5
        hide movie
        return

    label BASEMP4(xp = 0, yp = 0, scale = 1.0):
        show mp4:
            zoom scale
            xpos xp ypos yp
        pause
        pause 0.5
        hide mp4
        return

    label TEST:
        show im1:
            xpos 0 ypos 0
        pause
        hide im1
        return

    label GO(labelname="default"):
        call expression labelname
        return


    return
