label Story02:
    image blackscreen = "/Frollo-Casino1/black.jpg"
    image fuck001 = "/Hentai 01/001.jpg"
    image fuck002 = "/Hentai 01/002.jpg"
    image fuck003 = "/Hentai 01/003.jpg"
    image fuck004 = "/Hentai 01/004.jpg"

    define avtor = Character("..")
    call GO("Story02_01")

    label Story02_01:

        show fuck001 with fade:
            xalign 0.0 yalign 0.0
            zoom 1.0
        avtor "А в это время, в шикарном номере, куда граф привез Ольгу после ресторана..."
        hide fuck001
        show fuck002 with fade:
            xalign 0.0 yalign 0.0
            zoom 1.0
        avtor "А в это время, в шикарном номере, куда граф привез Ольгу после ресторана..."
        hide fuck002
        show fuck003 with fade:
            xalign 0.0 yalign 0.0
            zoom 1.0
        avtor "А в это время, в шикарном номере, куда граф привез Ольгу после ресторана..."
        hide fuck003
        show fuck004 with fade:
            xalign 0.0 yalign 0.0
            zoom 1.0
        avtor "А в это время, в шикарном номере, куда граф привез Ольгу после ресторана..."
        hide fuck004

        jump Story02_01
