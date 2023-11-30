#kordused
import math
from re import S

for x in range(1,10): #1,10
    R=float(input("{0}R: ".format(x))) #x+1
    if R>0:
        S=pi*r**2
    else:
        S="R peab > kui 0 olema"
    print("S={0}".format(S))

x=0
while True:
    x+=1
    R=float(input("{0}R: ".format(x))) #x+1
    if R>0:
        S=pi*r**2
    else:
        S="R peab > kui 0 olema"
    print("S={0}".format(S))
    if x==10:
        break

#10r
x=0
while x<10:
    x+=1
    R=float(input("{0}R: ".format(x))) #x+1
    if R>0:
        S=pi*r**2
    else:
        S="R peab > kui 0 olema"
    print("S={0}".format(S))

#10s
x=0
while x<10:
    R=float(input("{0}R: ".format(x))) #x+1
    if R>0:
        S=pi*r**2
        x+=1
    else:
        S="R peab > kui 0 olema"
    print("S={0}".format(S))

#1

for x in range(1,16):
    a=float(input("write number: "))
    if a.is_integer():
        t+=1
print(t)

#2

for x in range(1,a):
    a=int(input("Write number: "))
    sum_of_numbers += i
    print(f"Сумма всех натуральных чисел от 1 до {0} равна {1}".format(a,sum_of_numbers))

#3
p=1
for x in range(8):
    A=float(input("{0}. samm\n Sisesta A: ".format(x+1)))
    if A>0:
        p*=A
        lause=lause+str(A)+"*"
print(lause[:-1],"=",p)

#4

for x in range(10,21):
    a=x**2
    print(f"Квадрат числа {0}: {1}", .format(x,a))

#5

N = int(input("Введите количество чисел N: "))
sum_of_negatives = 0

for i in range(N):
    number = int(input(f"Введите число {i + 1}: "))
    if number < 0:
        sum_of_negatives += number

print(f"Сумма отрицательных чисел: {sum_of_negatives}")


#15(6)
for y in range(10):
    for x in range(9):
        print(x,end=" ")
    print()

#29(7)

for i in range (10):
    for x in range(9):
        if x==0 or i==x:
            print("0",end="")
        else:
            print("x", end="")
       print()

#7(8)

A = int(input("Введите значение A: "))
B = int(input("Введите значение B: "))
K = int(input("Введите значение K: "))

print(f"Числа, кратные {K}, из промежутка [{A}, {B}]:")
for number in range(A, B + 1):
    if number % K == 0:
        print(number)

#10(9)

numbers = []

for _ in range(10):
    num1 = float(input("Введите первое число: "))
    num2 = float(input("Введите второе число: "))
    numbers.append(max(num1, num2))

print("Большие числа из каждой пары:")
for number in numbers:
    print(number)

#13(10)

count = 0
summa = 0

for number in range(100, 1001):
    if number % 7 == 0:
        count += 1
        summa += number

print(f"Натуральные числа от 100 до 1000, кратные 7:")
print(f"Количество: {count}")
print(f"Сумма: {summa}")



#Tõlgi suhtlemise laused eesti keele ja lisa kommentaare koodi seletamiseks.(Vigadeotsing)

print("*** ИГРЫ С ЧИСЛАМИ ***")
print()

while 1:
    try:
        a = (abs(int(input("Введите целое число => "))
        break
    except ValueError:
         print("Это не целое число")

if a==0:
    print("Нет смысла ничего делать с нулём")
else:

    print("Определяем, сколько в числе чётных и сколько нечётных цифр")
    print()
    c==b==a
    paaris ==0
    paaritu == 0
    while b > 0;
            if b % 2 = 0:
                    paaris =+ 1
            else:
                    paaritu =+ 1
             b = b // 10
    
    print("Чётных цифр:"paaris)
    print("Нечётных цифр:"paaritu)
    print()

    print("*Переворачиваем* введённое число")
    print()
    b=0
    while a > 0
        number = a % 10
        a = a // 10
        b = b * 10
         b =+ number
    print("*Перевёрнутое* число", b)
    print()

    print(("Проверяем гипотезу Сиракуз")
    print()
    if c % 2 = 0:
        print("с - чётное число. Делим на 2.")
    else:
        print("с - нечётное число. Умножаем на 3, прибавляем 1 и делим на 2.")
    while c !== 1:
            if c % 2 = 0:
                    c == c / 2
            else:
                    c == (3*c + 1) / 2
                print(c, end=")
    print()
    print("Гипотеза верна'')
    

    
    





