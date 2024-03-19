# Zadanie 1
Zdefiniuj typ wyliczeniowy `WeightUnits` z jednostkami masy:
- G        - 1 gram
- DAG      - 10 gramów
- KG       - 1000 gramów
- T        - 1_000_000 gramów
- LB       - 453,59237 gramów (funt)
- OZ       - 1/16 lb (uncja)

# Zadanie 2
Zdefiniuj klasę `Weight`, która przechowuje masę dowolnego obiektu we właściwościach
 - `Value` - typu `double` z masą
 - `Unit`  - typu wyliczeniowego `WeightUnits`
Obie właściwości można odczytywać, ale nie można ich zmieniać!
 - 
# Zadanie 3
Zdefiniuj konstruktor prywatny bezargumentowy w klasie `Weight`.

# Zadanie 4
Zdefiniuj metodę statyczną o nazwie `Of` i dwoma parametrami: masą i jednostką, która zwraca obiekt klasy `Weight`,
jeśli masa jest nieujemną liczbą, a jednostka jest stała typu wyliczeniowego. W sytuacji niemożności utworzenia obiektu zgłoś wyjątek `ArgumentException`.

# Zadanie 5
Zdefiniuj metodę statyczną o nazwie `Parse`, której argumentem jest łańcuch zwierający masę z jednostką wg schematu:

<wartość> <jednostka>

np. 
"12,56 kg", "23,67 lb"

Jeśli łańcuch zawiera poprawną liczbę (nieujemną) i znaną jednostkę to zwróć obiekt klasy `Weight`. Jeśli łańcuch jest błędny to zgłoś wyjątek z powodem błędu np.
- "Nieznana jednostka masy!", 
- "Ujemna wartość masy!". 
- "Niepoprawny format liczby określającej masę!"

# Zadanie 6
Zdefiniuj prywatną metodę instancyjną o nazwie `ToGram`, która zwraca wartość masy jako typ `double` w gramach.

# Zadanie 7
Zaimplementuj w klasie `Weight` metodę interfejsu `IEquatable`, aby stwierdzać równość dwóch obiektów klasy `Weight`. 
Dwa obiekty są identycznej jeśli ich masy są identyczne, choć mogą być wyrażone w różnych jednostkach np. 100 gram = 10 dag, 50 kg = 0,05 t itd.

# Zadanie 8
Zaimplementuj w klasie `Weight` metodę interfejsu `IComparable`, aby określić, która masa jest większa, mniejsza lub równa np. 
10 dag jest większe od 80 gramów itd. Pamiętaj, że można porównywać masę w różnych jednostkach!

# Zadanie 9
Zdefiniuj operatory: większe `>`, mniejsze `<`, równe `==` i różne `!=`. 
Postaraj się wykorzystać już zdefiniowane metody, aby uniknąć powielania kodu. 

# Zadania do samodzielnego wykonania (mogą wystąpić w sprawdzianie)
1. Nadpisz metodę `ToString` w klasie `Weight`, aby zwracała łańcuch w postaci <value> <unit> np.:
```
10 kg
```

Jednostka powinna być zapisana małymi literami 
2. Zaimplementuj operator dodawania dwóch obiektów `Weight`, wynikiem jest jest obiekt `Weight` z zwiększą jednostką masy 
spośród dwóch argumentów np.
110 G + 0.5 KG = 0.65 KG
3. Zaimplementuj metodę `ToUnit(unit)`, gdzie `unit` jest stałą jednostki. Metoda powinna zwrócić obiekt `Weight` z ekwiwaletną wartością masy
we wskazanej w argumencie metody np.

```C#
Weight w = Weight.Of(10.0, WeightUnits.KG);
Weight wInGram = w.ToUnit(WeightUnits.G);
Console.WriteLine(wInGram);
```
Efektem jest napis
```
10000 g
```
4. Zaimplementuj operator mnożenia obiektu `Weight` przez dowolną liczbę zmiennoprzecinkową: `double` i `float`. Wynikiem jest przeskalowana masa w tej samej jednostce.