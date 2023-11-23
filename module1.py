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



  

        


