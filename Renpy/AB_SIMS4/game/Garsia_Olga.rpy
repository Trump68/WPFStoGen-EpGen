image v_OlgaGarsia_01 = Movie(play = "/Garsia_Olga/001.mp4", mask = "/Garsia_Olga/001MASK.mp4")
image v_OlgaGarsia_02 = Movie(play = "/Garsia_Olga/002.mp4", mask = "/Garsia_Olga/002MASK.mp4")
image v_OlgaGarsia_03 = Movie(play = "/Garsia_Olga/003.mp4", mask = "/Garsia_Olga/003MASK.mp4")
image v_OlgaGarsia_04 = Movie(play = "/Garsia_Olga/004.mp4", mask = "/Garsia_Olga/004MASK.mp4")
image v_OlgaGarsia_05 = Movie(play = "/Garsia_Olga/005.mp4", mask = "/Garsia_Olga/005MASK.mp4")
image v_OlgaGarsia_10 = Movie(play = "/Garsia_Olga/a_idle_female_Sway-01.mp4", mask = "/Garsia_Olga/a_idle_female_Sway-01_MASK.mp4")
image v_OlgaGarsia_11 = Movie(play = "/Garsia_Olga/a_idle_female_Sway2-01.mp4", mask = "/Garsia_Olga/a_idle_female_Sway2-01_MASK.mp4")
image v_OlgaGarsia_12 = Movie(play = "/Garsia_Olga/a_idle_female_Sway2_Worry-01.mp4", mask = "/Garsia_Olga/a_idle_female_Sway2_Worry-01_MASK.mp4")
image v_OlgaGarsia_13 = Movie(play = "/Garsia_Olga/a_idle_female_Sway2_Worry-02.mp4", mask = "/Garsia_Olga/a_idle_female_Sway2_Worry-02_MASK.mp4")
image v_OlgaGarsia_14 = Movie(play = "/Garsia_Olga/a_idle_female_Sway2_Worry_Legs2_01.mp4", mask = "/Garsia_Olga/a_idle_female_Sway2_Worry_Legs2_01_MASK.mp4")
image v_OlgaGarsia_15 = Movie(play = "/Garsia_Olga/a_idle_female_Sway2_Worry_Legs2_02.mp4", mask = "/Garsia_Olga/a_idle_female_Sway2_Worry_Legs2_02_MASK.mp4")
image v_OlgaGarsia_16 = Movie(play = "/Garsia_Olga/a_idle_female_Sway2_Worry_Legs2_03.mp4", mask = "/Garsia_Olga/a_idle_female_Sway2_Worry_Legs2_03_MASK.mp4")
image v_OlgaGarsia_Mast_01 = Movie(play = "/Garsia_Olga/Amra72_Floor_Mast_f_y_01_01.mp4", mask = "/Garsia_Olga/Amra72_Floor_Mast_f_y_01_01_MASK.mp4")
image v_OlgaGarsia_Mast_02 = Movie(channel = "",play = "/Garsia_Olga/Amra72_Floor_Mast_f_y_01_02.mp4", mask = "/Garsia_Olga/Amra72_Floor_Mast_f_y_01_02_MASK.mp4")

label GarsiaOlga_01:
    label OlgaGarsia_Show:
        #show bg black
        show dancignHall:
            xalign 0.0 yalign 0.0
        #call OlgaGarsia_01_03

    label OlgaGarsia_Mast_02:
        show v_OlgaGarsia_Mast_02:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_Mast_02

    label OlgaGarsia_Mast_01:
        show v_OlgaGarsia_Mast_01:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_Mast_01

    label OlgaGarsia_01_16:
        show v_OlgaGarsia_16:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_16

    label OlgaGarsia_01_15:
        show v_OlgaGarsia_15:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_15

    label OlgaGarsia_01_14:
        show v_OlgaGarsia_14:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_14

    label OlgaGarsia_01_13:
        show v_OlgaGarsia_13:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_13

    label OlgaGarsia_01_12:
        show v_OlgaGarsia_12:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_12


    label OlgaGarsia_01_11:
        show v_OlgaGarsia_11:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_11


    label OlgaGarsia_01_10:
        show v_OlgaGarsia_10:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_10
    call OlgaGarsia_Show

    label OlgaGarsia_01_05:
        show v_OlgaGarsia_05:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_05

    label OlgaGarsia_01_04:
        show v_OlgaGarsia_04:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_04

    label OlgaGarsia_01_03:
        show v_OlgaGarsia_03:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_03

    label OlgaGarsia_01_02:
        show v_OlgaGarsia_02:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_02

    label OlgaGarsia_01_01:
        show v_OlgaGarsia_01:
            zoom 1.0
            xpos 0 ypos 0
        pause
        hide v_OlgaGarsia_01

    call OlgaGarsia_Show
