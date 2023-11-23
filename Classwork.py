  #kalkulaator
try:
    a=float(input("Esimene arv:"))
    try:
        print("Vale andmetuup")
        t=input("Tehe:")
        if t in ['+','-','/','*','**','//']:
            if t=='+':
                v=a+b
            elif t=='-':
                v=a-b
            elif t=='*':
                v=a*b
            elif t=='**':
                v=a**b
            elif t=='/':
                if b==0:
                    v="DIV/8"
                else:
                    v=a/b
            print("{0}{1}{2}={3}".format(a,t,b,v))
        else:
            print("Tundmatu mark")
    except:
        print("vale b")

    pass
else:
    print("Tundmatu mark")
 
 
 
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



