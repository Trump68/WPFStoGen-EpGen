label Story01:
    image olga_hause = "/!Locations/Olga Hause/Olga Hause 0000000001.png"
    define rabikus_evil = Character("Rabikus")
    call GO("Story01_01")

    label Story01_01:
        show olga_hause:
            xalign 0.0 yalign 0.0
        image rabikus 001 = "/!Rabikus/Rabikus 0000000001.png"
        image rabikus 012 = "/!Rabikus/Rabikus 0000000012.png"
        image olga 001 = "/!Olga/KB random poses N33  29.png"
        show rabikus 001:
            xpos 50 ypos 170
            zoom 0.7
        show olga 001:
            xpos 0 ypos 0
            zoom 1.0
        rabikus_evil "Не волнуйся"
        hide rabikus 001
        hide olga 001

        show rabikus 012:
            xpos -250 ypos -70
            zoom 1.6
        show olga 001:
            xpos 0 ypos 0
            zoom 1.0
        pause
        hide rabikus 012
        hide olga 001
        show bg black
        call Amra72FloorMast_01_03_01
        # call Amra72DoubleBedCowgirl_03_02_01
        # call Amra72DoubleBedCowgirl_02_01_01
        # call Amra72DoubleBedCowgirl_02_01_02
        # call Amra72DoubleBedCowgirl_02_01_03
        # call Amra72DoubleBedCowgirl_02_01_04
        # call Amra72DoubleBedCowgirl_02_01_05
        # call Amra72DoubleBedCowgirl_03_01_01
        jump Story01_01
