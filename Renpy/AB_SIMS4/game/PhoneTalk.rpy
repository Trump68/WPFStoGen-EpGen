label PhoneTalk:
    $ dirname = "PhoneTalk"

    show dancignHall:
        xalign 0.0 yalign 0.0

    call GO("PhoneTalk_01_01_01") from _call_GO_3

    label PhoneTalk_01_01_01: #750 from 1030 only works !!!!!
        call BASEPNG('01',  1030, 0.02, True, False, True,  1, 0.02, 0.02, 100, 50, scale = 0.7) from _call_BASEPNG_10
        return
