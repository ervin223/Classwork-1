# Запрос у пользователя пяти имен
names = [input(f"Введите имя {i + 1}: ") for i in range(5)]

# Отображение имен в алфавитном порядке
sorted_names = sorted(names)
print("Имена в алфавитном порядке:", sorted_names)

# Отображение последнего добавленного имени
last_added_name = names[-1]
print("Последнее добавленное имя:", last_added_name)

# Возможность изменить имена в списке
index_to_change = int(input("Введите индекс имени, которое хотите изменить (от 0 до 4): "))
new_name = input("Введите новое имя: ")
names[index_to_change] = new_name
print("Список имен после изменения:", names)

# Список с несколькими одинаковыми именами
students = ['Юхан', 'Кати', 'Марио', 'Марио', 'Мати', 'Мати']

# Исключение дубликатов
unique_students = list(set(students))
print("Список без дубликатов:", unique_students)

# Список возрастов
ages = [20, 25, 30, 22, 18]

# Нахождение наибольшего и наименьшего числа, суммы и среднего чисел
max_age = max(ages)
min_age = min(ages)
sum_ages = sum(ages)
average_age = sum_ages / len(ages)

print(f"Наибольший возраст: {max_age}")
print(f"Наименьший возраст: {min_age}")
print(f"Сумма возрастов: {sum_ages}")
print(f"Средний возраст: {average_age}")

