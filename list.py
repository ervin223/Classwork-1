#4

towns = {
    1: "Tallinn",
    2: ["Narva", "Narva Joesuu"],
    3: "Kohtla Jarve",
    4: "Ida Virumaa",
    5: "Tartu",
    6: "Tartumaa",
    7: "Viljandimaa",
    8: "Parnumaa",
    9: "Saaremaa"
}

while True:
    try:
        user_input = input("Введите номер города или области (от 1 до 9): ")
        if len(user_input) == 1 and user_input.isdigit():
            user_input = int(user_input)
            if 1 <= user_input <= 9:
                result = towns[user_input]
                print(f"Выбранный город или область: {result}")
                if user_input in [1, 2, 3]:
                    print("Оставайтесь дома")
                else:
                    print("Носите маски")
                break
            else:
                print("Пожалуйста, введите число от 1 до 9.")
        else:
            print("Пожалуйста, введите ровно одну цифру.")
    except ValueError:
        print("Ошибка: Введите корректное число.")
    except KeyError:
        print("Ошибка: Нет данных для введенного номера.")


#5

elements = int(input("Сколько элементов?"))

list_1 = []

for i in range(elements):
    name = input("Введите название: ")
    list_1.append(name)

print(list_1)

while True:
    try:
        change = int(input("Что надо поменять? "))
        if change % 2 == 0:
            break
        else:
            print("Пожалуйста, введите четное число.")
    except ValueError:
        print("Попробуйте еще раз, введите целое число.")

#6

kokku = randint(2,20)
print("", kokku,"elementi")
num_list = []
for i in range (kokku):
    num_list.append(round(random()*1000,2))
print(num_list)
max_=max(num_list)
n = num_list.index(max_)
print("\t"max_,"position: ", n+t)
num_list.pop(n)
max_ = max_/len(num_list)
num_list.insert(n,max_)
print(num_list)

#7
 
print("7")

numeric = randint(2,20)
numeric_list = []
for i in range(numeric):
    numeric_list.append(randint(-1000,1000))
print(numeric_list)
print()
print("len") +str(len(numeric_list))
for i in range(0,numeric,1):
    numeric_list[i] = abs(numeric_list[i])

numeric_list.sort()
print(numeric_list)
