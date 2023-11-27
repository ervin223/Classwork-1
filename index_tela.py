
print("Tere! Olen sinu uus sober - Python!")
nimi = str(input("Kirjuta sinu nimi: "))
print(nimi + ", oi kui ilus nimi!")

try:
    answer = int(input("Kas leian Sinu keha indeksi? 0-ei, 1-jah =>: "))
    
    if answer == 1:
        pikkus = int(input("Kirjuta sinu pikkus (cm): "))
        mass = float(input("Kirjuta sinu mass (kg): "))
        indeks = mass / ((pikkus * 0.01) * (pikkus * 0.01))
        print("Sinu keha indeks on:", round(indeks, 1))
        
        if indeks < 16:
            print("Tervisele ohtlik alakaal")
        elif 16 < indeks < 19:
            print("Alakaal")
        elif 19 < indeks < 25:
            print("Normaalkaal")
        elif 25 < indeks < 30:
            print("Ulekaal")
        elif 30 < indeks < 35:
            print("Rasvumine")
        elif 35 < indeks < 40:
            print("Tugev rasvumine")
        elif indeks >= 40:
            print("Ohtlik tervisele")
    elif answer == 0:
        print("Kahju, see on vaga oluline info")
    else:
        print("Vale sisend. Valige 0 voi 1.")
except ValueError:
    print("Vale sisend. Palun sisestage arv.")

print("Kohtumiseni, " + nimi + "! Igavesti Sinu, Python!")
