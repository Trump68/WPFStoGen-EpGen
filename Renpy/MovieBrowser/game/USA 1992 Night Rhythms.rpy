label USA_1992_Night_Rhythms:
    $ dirname = "USA 1992 Night Rhythms"

    call GO("USA_1992_Night_Rhythms_02_2")


    label USA_1992_Night_Rhythms_01_1:
        call BASE("01",  135, 0.075, True, True, True,   1, 0.1, 0.1)
        return
    label USA_1992_Night_Rhythms_01_2:
        call BASE("01",  33, 0.075, True, True, True, 136, 0.1, 0.1)
        return

    label USA_1992_Night_Rhythms_02_1:
        call BASE("02",  358, 0.075, True, True, True,   1, 0.1, 0.1)
        return
    label USA_1992_Night_Rhythms_02_2:
        call BASE("02",  383, 0.075, True, True, True,  359, 0.1, 0.1)
        return
