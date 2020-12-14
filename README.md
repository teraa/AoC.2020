```console
cd Day/
dotnet run < input.txt
dotnet run < input.txt | diff -w <(echo "expected") - && echo OK
```
