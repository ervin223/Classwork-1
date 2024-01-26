from random import *

def failist_sonastikuks(f: str):
    riik_pealinn = {}
    pealinn_riik = {}
    riigid = []

    with open(f, 'r', encoding="utf-8-sig") as fail:
        for rida in fail:
            riik, pealinn = rida.strip().split('-')
            riik_pealinn[riik] = pealinn 
            pealinn_riik[pealinn] = riik 
            riigid.append(riik)

    return riik_pealinn, pealinn_riik, riigid

def kuvatud_pealinn(riik_pealinn, riik):
    if riik in riik_pealinn:
        return riik_pealinn[riik]
    else:
        return f"Riigi '{riik}' pealinna ei leitud."

def kuvatud_riik(pealinn_riik, pealinn):
    if pealinn in pealinn_riik:
        return pealinn_riik[pealinn]
    else:
        return f"Riiki, mille pealinn on '{pealinn}', ei leitud."

def lisa_sissekanne(riik_pealinn, pealinn_riik):
    uus_riik = input("Sisestage uue riigi nimi: ")
    uus_pealinn = input("Sisestage uue pealinna nimi: ")

    riik_pealinn[uus_riik] = uus_pealinn
    pealinn_riik[uus_pealinn] = uus_riik

    print(f"Uus sissekanne lisatud: {uus_riik} - {uus_pealinn}")

def paranda_vea(riik_pealinn, pealinn_riik):
    vigane_element = input("Sisestage riigi või pealinna nimi vea parandamiseks: ")

    if vigane_element in riik_pealinn:
        uus_pealinn = input(f"Aktuaalne pealinn riigile {vigane_element}: {riik_pealinn[vigane_element]}\nSisestage uus pealinn: ")
        pealinn_riik[riik_pealinn[vigane_element]] = None
        riik_pealinn[vigane_element] = uus_pealinn
        pealinn_riik[uus_pealinn] = vigane_element
        print(f"Vea parandamine õnnestus: {vigane_element} - {uus_pealinn}")
    elif vigane_element in pealinn_riik:
        uus_riik = input(f"Aktuaalne riik pealinnale {vigane_element}: {pealinn_riik[vigane_element]}\nSisestage uus riik: ")
        riik_pealinn[pealinn_riik[vigane_element]] = None
        pealinn_riik[vigane_element] = uus_riik
        riik_pealinn[uus_riik] = vigane_element
        print(f"Vea parandamine õnnestus: {uus_riik} - {vigane_element}")
    else:
        print(f"Elementi '{vigane_element}' ei leitud sõnastikust.")

riik_pealinn, pealinn_riik, riigid = failist_sonastikuks("riigid_pealinnad.txt")

def kontrolli_znang(riik_pealinn, pealinn_riik, riigid):
    oige_vastus = 0

    suvaline_element = choice(riigid)

    if randint(0, 1) == 0:
        vastus = input(f"Mis on riigi pealinn nimega '{suvaline_element}'? ")
        oige_vastus = kuvatud_pealinn(riik_pealinn, suvaline_element)
    else:
        vastus = input(f"Mis riik on pealinna nimega '{suvaline_element}'? ")
        oige_vastus = kuvatud_riik(pealinn_riik, suvaline_element)

    if vastus.lower() == oige_vastus.lower():
        print("Õige vastus!")
        return 1
    else:
        print(f"Vale vastus! Õige vastus on: {oige_vastus}")
        return 0

riik_pealinn, pealinn_riik, riigid = failist_sonastikuks("riigid_pealinnad.txt")

while True:
    valik = input("Valige, kas sisestada riik (r), pealinn (p), parandada viga (v), kontrollida teadmisi (k) või lõpetada (l): ").lower()

    if valik == 'r':
        riik = input("Sisestage riigi nimi: ")
        print(kuvatud_pealinn(riik_pealinn, riik))
    elif valik == 'p':
        pealinn = input("Sisestage pealinna nimi: ")
        print(kuvatud_riik(pealinn_riik, pealinn))
    elif valik == 'v':
        paranda_vea(riik_pealinn, pealinn_riik)
    elif valik == 'k':
        kordamine = int(input("Mitu küsimust soovite vastata? "))
        oiged_vastused = 0

        for _ in range(kordamine):
            oiged_vastused += kontrolli_znang(riik_pealinn, pealinn_riik, riigid)

        tulemus_protsentides = (oiged_vastused / kordamine) * 100
        print(f"\nKokku saite õigesti {oiged_vastused} küsimust {kordamine} kohta. Tulemus: {tulemus_protsentides:.2f}%\n")
    elif valik == 'l':
        break
    else:
        print("Vale valik! Palun valige 'r', 'p', 'v', 'k' või 'l'.")

    lisavalik = input("Kas soovite jätkata? (j/e): ").lower()
    if lisavalik != 'j':
        break
    else:
        lisa_sissekanne(riik_pealinn, pealinn_riik)
        

