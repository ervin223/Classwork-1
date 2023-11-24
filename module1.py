from datetime import datetime
import math

#1
while True:
    name = str(input("Put your name: "))
    if name == "Juku":
        print("Go to the cinema with Juku")
        break
    else:
        print("Wrong name. Please enter it again.")

age = int(input("Put your age: "))
if age < 0:
    print("Wrong age")
elif 6 <= age <= 14:
    print("Child ticket")
elif 15 <= age <= 65:
    print("Usual ticket")
elif age > 65:
    print("Soodustus")
elif age > 100:
    print("Child ticket")

    #2
person_1=str(input("write your name"))
print("you sit with person 2")
person_2=str(input("write your name"))
print("you sit with person 1")

#3
a=float(input("First side:"))
b=float(input("Second side:"))
s=print(a*b)
quastion=str(input("do u want change the floor"))
if quastion == yes:
    print("how many cost one metr of floor")

    #4
price=floar(input("write number"))
discount=0.3
if price>700:
    print(price*discount)
else:
    print(price)

    #5
temperature=float(input("write the temperature"))
if temperature>18:
    print("in winter times room temperature is better")

#6 
height=float(input("write your height"))
if height<160:
    print("small")
elif 160<height<180:
    print("medium")
else:
    print("tall")

#7
height=float(input("write your height"))
gender=str(input("write your gender"))
if height>180:
    print("medium")
else:
    print("tall")

#8
shop=str(input("what u want to buy milk or bread"))
milk=2 
bread=1
if milk:
    print(2)
elif bread:
    print(1)
elif milk+bread:
    print(3)

#9
a=float(input("write side: "))
b=float(input("write side: "))
c=float(input("write side: "))
d=float(input("write side:"))
if a==b==c==d:
    print("square")
else:
    print("not a square")

#10
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
            elif t == '/':
                if b == 0:
                    v = "DIV/0"  
                else:
                    v = a / b
            print("{0} {1} {2} = {3}".format(a, t, b, v))
        else:
            print("Tundmatu mark")
    except:
        print("Vale tehte sisend")
except ValueError:
    print("Vale arv sisend")
except ZeroDivisionError:
    print("Nulliga jagamine")
    
#11

current_date = datetime.now()
birthdate_input = input("Введите дату рождения в формате 'YYYY-MM-DD': ")
age = current_date.year - birth_date.year - ((current_date.month, current_date.day) < (birth_date.month, birth_date.day))
if age % 25 == 0:
    print(f"Поздравляем! Ваш {age} является юбилейным!")
else:
    print(f"Ваш {age} не является юбилейным.")
    
#12

price_1 = float(input("Write price: "))
price_2 = price_1

if price_1 < 10:
    price_2 = price_1 - price_1 * 0.1
    print(price_2)
else:
    price_2 = price_1 - price_1 * 0.2
    print(price_2)
    
#13

while True:
    gender=str(input("Man or woman: "))
    if gender == "woman":
        break
    else:
        age=int(input("Put age: "))
        if 16<=age<=18:
            print("succesful")
        else:
            print("not succesful")
            
#14

people = int(input("write number of people: "))
spots_bus = int(input("write number of spots: "))

if people <= spots_bus:
    print("succesful")
else:
    buses = math.ceil(people / spots_bus)
    print("{} buses you need".format(buses))

        
    
    




    
    









  

        


