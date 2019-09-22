label SIMS4_Anims:
    $ dirname = "SIMS4_Anims"

    call GO("SIMS4_Anims_01_01")

    label SIMS4_Anims_01_01:
        call BASEPNG('01',  900, 0.02, True, False, True,  1, 0.02, 0.02)
        return
