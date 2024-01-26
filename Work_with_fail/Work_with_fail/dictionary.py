from random import *

def loe_sonastik_vene(file_path):
    sonastik = {}
    with open(file_path, 'r', encoding='utf-8') as file:
        for line in file:
            if '-' in line:
                vene, eesti = line.strip().split('-')
                sonastik[vene] = eesti
            else:
                print(f"{line.strip()}")

    return sonastik

def kirjuta_sonastik_vene(file_path, sonastik):
    with open(file_path, 'w', encoding='utf-8') as file:
        for vene, eesti in sonastik.items():
            file.write(f"{vene}-{eesti}\n")

def tolgi_sonad(vene_sonastik, vene_sona):
    return vene_sonastik.get(vene_sona, None)

def lisa_uus_sona(vene_sonastik, vene_sona, eesti_sona):
    vene_sonastik[vene_sona] = eesti_sona
    print(f"Sõna lisatud: {vene_sona} - {eesti_sona}")

def paranda_vea(vene_sonastik, vene_sona):
    if vene_sona in vene_sonastik:
        print(f"Aktuaalne eestikeelne tõlge sõnale '{vene_sona}': {vene_sonastik[vene_sona]}")
        uus_eesti_tollimus = input("Sisestage uus eestikeelne tolge: ")
        vene_sonastik[vene_sona] = uus_eesti_tollimus
        print(f"Viga parandatud: {vene_sona} - {uus_eesti_tollimus}")
    else:
        print(f"Sona '{vene_sona}' ei leitud sonastikust.")

def kontrolli_znaniye(vene_sonastik):
    oiged_vastused = 0
    kokku_kusimusi = 0

    kordamine = int(input("Mitu kusimust soovite vastata? "))

    for _ in range(kordamine):
        vene_sona = choice(list(vene_sonastik.keys()))
        eesti_tollimus = input(f"Kuidas tolgite sona '{vene_sona}' eesti keelde? ")
        oigevastus = vene_sonastik[vene_sona]
        if eesti_tollimus.lower() == oigevastus.lower():
            print("oige vastus!")
            oiged_vastused += 1
        else:
            print(f"Vale vastus! oige vastus on: {oigevastus}")
        kokku_kusimusi += 1

    tulemus_protsentides = (oiged_vastused / kokku_kusimusi) * 100
    print(f"\nKokku õigeid vastuseid: {oiged_vastused} {kokku_kusimusi} kohta. Tulemus: {tulemus_protsentides:.2f}%\n")

vene_faili_nimi = "dictionary_rus.txt"
eesti_faili_nimi = "dictionary_est.txt"

vene_sonastik = loe_sonastik_vene(vene_faili_nimi)

vene_sona = input("Sisestage vene sõna: ")
eesti_tollimus = tolgi_sonad(vene_sonastik, vene_sona)

if eesti_tollimus:
    print(f"Tõlge: {eesti_tollimus}")
else:
    print("Seda sõna pole tõlgitud. Kas soovite lisada tõlke?")
    lisa_uus_sona(vene_sonastik, vene_sona, input("Sisestage eestikeelne tõlge: "))

paranda_valik = input("Kas soovite parandada vigu? (y/n): ").lower()
if paranda_valik == 'y':
    vene_sona_parandamiseks = input("Sisestage vene sõna, mille tõlget soovite parandada: ")
    paranda_vea(vene_sonastik, vene_sona_parandamiseks)
    
kontrolli_valik = input("Kas soovite kontrollida sõnade tundmist? (y/n): ").lower()
if kontrolli_valik == 'y':
    kontrolli_znaniye(vene_sonastik)

kirjuta_sonastik_vene(vene_faili_nimi, vene_sonastik)
