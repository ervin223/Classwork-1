shop=str(input("what u want to buy milk or bread"))
milk=2 
bread=1
if milk:
    print(2)
elif bread:
    print(1)
elif milk and bread:
    print(3)
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
shop=str(input("what u want to buy milk or bread"))
milk=2 
bread=1
if milk:
    print(2)
elif bread:
    print(1)
elif milk+bread:
    print(3)






  

        


