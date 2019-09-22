label Story01:
    image blackscreen = "/Frollo-Casino1/black.jpg"
    image fuck001 = "/Frollo-Casino1/001.jpg"
    image fuck003 = "/Frollo-Casino1/003.jpg"
    image fuck004 = "/Frollo-Casino1/004.jpg"
    image fuck005 = "/Frollo-Casino1/005.jpg"
    image fuck006 = "/Frollo-Casino1/006.jpg"
    define avtor = Character("..")
    call GO("Story01_01")

    label Story01_01:

        show fuck001:
            xalign 0.0 yalign 0.0
            #xpos 50 ypos 170
            zoom 0.7
        avtor "А в это время, в шикарном номере, куда граф привез Ольгу после ресторана..."
        hide fuck001
#        show blackscreen
#        $ renpy.pause (0.5, hard=True)
        show fuck003 with fade:
            zoom 0.7
        avtor "Граф казался неутомимым и ненасытным..."
        hide fuck003
        show fuck004 with fade:
            zoom 0.7
        pause
        hide fuck004
        show fuck005 with fade:
            zoom 0.7
        pause
        hide fuck005
        show fuck006 with fade:
            zoom 0.7
        pause
        hide fuck006

        jump Story01_01
