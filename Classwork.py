  #1. Определить и вывести большее из двух вводимых чисел. Составить блок-схему программы подсчета суммы только отрицательных из трех данных чисел.
  #Составить блок-схему программы радиоуправляемой машинки. Проверить правильность вводимого личного кода у N  человек.
  
  #1
first = float(input("Write number: "))
second = float(input("Write second number: "))

if first > second:
    print("First is bigger than second")
else:
    print("Second is bigger than first")

#2
first = float(input("Write number: "))
second = float(input("Write second number: "))
third = float(input("Write third number"))
if first and second and third < 0:
    print(first+second+third)
else:
    print("Number should be bigger than 0")


  
  
  
  
  #toetus

grupp=input("ruhma nimetus: ")
if grupp=="Targv23":
    puudumised=int(input("Mitu puudumist sul on:"))
    if puudumised<15:
        hinne=float(input("Mis on keskmine hinne:"))
        if hinne>3.8:
            print("Toetus")
        else:
            print("Liga madal keskmine hind. Toetust ei ole")
    else:
        print("Toetus ei maaratakse")
else:
    print("Ruhma nimetus ei sobi")

grupp=input("ruhma nimetus: ")
puudumised=int(input("Mitu puudumist sul on:"))
hinne=float(input("Mis on keskmine hinne:"))
if grupp=="Targv23" and puudumised<15 and hinne>3.8:
    print("Toetus!")
else:
    print("Toetust ei ole!")

  
  #kalkulaator
try:
    a = float(input("Esimene arv: "))
    b = float(input("Teine arv: "))
    try:
        t = input("Tehe: ")
        if t in ['+', '-', '/', '*', '**', '//']:
            if t == '+':
                v = a + b
            elif t == '-':
                v = a - b
            elif t == '*':
                v = a * b
            elif t == '**':
                v = a ** b
            elif t == '/':
                if b == 0:
                    v = "DIV/0"  
                else:
                    v = a / b
            elif t == '//':
                v = a // b
            print("{0} {1} {2} = {3}".format(a, t, b, v))
        else:
            print("Tundmatu mark")
    except:
        print("Vale tehte sisend")
except ValueError:
    print("Vale arv sisend")
except ZeroDivisionError:
    print("Nulliga jagamine")

 
 
 #kolmnurk
a=float(input("Alpha:"))
b=float(input("Betta:"))
c=float(input("Gamma:"))
if a>0 and b>0 and c>0:
    if a+b+c==180:
        print("Kolmnurk")
    else:
        print("Nurgad")
else:
    print("Andmed on vale")



