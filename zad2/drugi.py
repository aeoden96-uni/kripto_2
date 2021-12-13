
U = "sxfitsh"
V = "vrzskum"


first_letter = "spnd"
alfa= "abcdefghijklmnopqrstuvwxyz"

length = len(U)



def n(a):
    return ord(a) - 97

def find_pair():
    for i in first_letter:
        if alfa[(n(V[0])-n(U[0])+n(i)) % 26] in first_letter:
            return i,alfa[(n(V[0])-n(U[0])+n(i)) % 26]

b,a=find_pair()

bb = []
aa = []

with open("rjecnik.txt") as file:
    lines = file.readlines()
    for line in lines:
        line = line.rstrip()
        if len(line) == length:
            if line[0] == b:
                bb.append(line)
            elif line[0] == a:
                aa.append(line)


for A in aa:
    for B in bb:
        good = True
        for a,b,u,v in zip(A,B,U,V):
            if (n(v) - n(u) + n(b)) % 26 != n(a):
                good = False
        if good:
            print(B)
            print(A)



