image video_Amra72FloorMast_01_01_01 = Movie(play = "/Amra72FloorMast/01/Stage01_01.mp4", mask = "/Amra72FloorMast/01/Stage01_01_MASK.mp4")
image video_Amra72FloorMast_01_02_01 = Movie(play = "/Amra72FloorMast/01/Stage01_02.mp4", mask = "/Amra72FloorMast/01/Stage01_02_MASK.mp4")
image video_Amra72FloorMast_01_03_01 = Movie(play = "/Amra72FloorMast/01/Stage01_03.mp4", mask = "/Amra72FloorMast/01/Stage01_03_MASK.mp4")

label Amra72FloorMast_01:
    show dancignHall:
        xalign 0.0 yalign 0.0

    label Amra72FloorMast_01_01_01:
        show video_Amra72FloorMast_01_01_01:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide video_Amra72FloorMast_01_01_01
        return

    label Amra72FloorMast_01_02_01:
        show video_Amra72FloorMast_01_02_01:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide video_Amra72FloorMast_01_02_01
        return

    label Amra72FloorMast_01_03_01:
        show video_Amra72FloorMast_01_03_01:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide video_Amra72FloorMast_01_03_01
        return
