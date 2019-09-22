label Amra72DoubleBedCowgirl_01:
    show dancignHall:
        xalign 0.0 yalign 0.0

    # call GO("Amra72DoubleBedCowgirl_01_01_02")

    label Amra72DoubleBedCowgirl_01_01_01:
        image mp4 = Movie(fps=60, play = "/Amra72DoubleBedCowgirl_01/01/Tea_01_01.mp4", mask = "/Amra72DoubleBedCowgirl_01/01/Tea_01_01_MASK.mp4")
        call BASEMP4(xp = 0, yp = 0, scale = 0.7)
        return
    label Amra72DoubleBedCowgirl_01_01_02:
        image mp4 = Movie(fps=60, play = "/Amra72DoubleBedCowgirl_01/02/Tea_01_02.mp4", mask = "/Amra72DoubleBedCowgirl_01/02/Tea_01_02_MASK.mp4")
        call BASEMP4(xp = 0, yp = 0, scale = 0.7)
        return
