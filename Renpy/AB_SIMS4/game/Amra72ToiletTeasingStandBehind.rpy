label Amra72ToiletTeasingStandBehind:
    $ dirname = "Amra72ToiletTeasingStandBehind"

    show dancignHall:
        xalign 0.0 yalign 0.0

    call GO("Amra72ToiletTeasingStandBehind_01_01_04")

    label Amra72ToiletTeasingStandBehind_01_01_01: #750 from 784 only works !!!!!
        call BASEPNG('01',  784, 0.02, True, False, True,  1, 0.02, 0.02, 100, 50, scale = 0.5)
        #call TEST
        return

    label Amra72ToiletTeasingStandBehind_01_01_02: #750 from 784 only works !!!!!
        call BASEPNG('02',  784, 0.02, True, False, True,  1, 0.02, 0.02, 100, 50, scale = 1.0)
        return
    label Amra72ToiletTeasingStandBehind_01_01_03:
        call BASEPNG('03',  784, 0.02, True, False, True,  1, 0.02, 0.02, 100, 50, scale = 1.0)
        return
    label Amra72ToiletTeasingStandBehind_01_01_04:
        call BASEPNG('04',  780, 0.02, True, False, True,  1, 0.02, 0.02, 100, 50, scale = 1.0)
        return
