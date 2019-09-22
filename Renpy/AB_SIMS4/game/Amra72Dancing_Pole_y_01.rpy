image dancignHall = "Locations/DancingHall/index.jpg"


label Amra72Dancing_Pole_y_01:
    $ dirname = "Amra72Dancing_Pole_y_01"

    show dancignHall:
        xalign 0.0 yalign 0.0

    call GO("Amra72Dancing_Pole_y_01_01_04") from _call_GO_1

    label Amra72Dancing_Pole_y_01_01_01: #750 from 900 only works !!!!!
        call BASEPNG('01',  900, 0.02, True, True, True,  1, 0.02, 0.02, 0, -30, scale = 0.7) from _call_BASEPNG_5
        return

    label Amra72Dancing_Pole_y_01_01_02: #750 from 900 only works !!!!!
        call BASEPNG('02',  900, 0.02, True, True, True,  1, 0.02, 0.02, 0, -30, scale = 0.7) from _call_BASEPNG_6
        return

    label Amra72Dancing_Pole_y_01_01_03: #750 from 900 only works !!!!!
        call BASEPNG('03',  600, 0.01, True, True, True,  1, 0.01, 0.01, 0, -30, scale = 0.7) from _call_BASEPNG_7
        return

    label Amra72Dancing_Pole_y_01_01_04: #750 from 900 only works !!!!!
        call BASEPNG('04',  400, 0.01, True, True, True,  1, 0.01, 0.01, 0, 0) from _call_BASEPNG_8
        return
