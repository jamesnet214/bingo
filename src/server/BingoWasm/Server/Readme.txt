# EF Core ����!!

## dotnet ef core ��ġ ��ɾ� 
```powershell
dotnet tool install --global dotnet-ef
```

## ef core Migration ��ɾ� 
```
dotnet ef migrations add BingoWord2
```
- BingoWord2�� Migration���� ��Ī���� �ߺ������ʰԸ� ���� �� ��
- �� ��ɾ� ����� ���Ե� ���̺� Ŭ������ ���� ���̱׷��̼� �ڵ� ������ �������ݴϴ�.
## Migration ���� ��ɾ�
```
dotnet ef database update
```
- �� ��ɾ� ����� Migration �ڵ��� Db�� �����մϴ�.
## Custom Class�� Migration ��� ���Խ�Ű�� �ʹٸ�..
```
public DbSet<BingoWord> BingoWords { get; set; }
```
- �� ���¿� ���� DbContext�� ��ӹ޴� Ŭ�������Ͽ� �־��ݴϴ�. 
## ���� Db => Class �ϰ� ������ ?
```
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=MyPassword881512;database=myDb;" Pomelo.EntityFrameworkCore.MySql 
```
- �� Pomelo.EntityFrameWorkCore.MySql ��  MySql���� ���°� �Դϴ�.  SqlServer�� Microsoft.EntityFrameworkCore.SqlServer �� �����Ͻø� �˴ϴ�.  (��Ű�� �̸�)

- ��ĳ���带 �� ���ϰ� �ϰ������ ? 
[EF Core Power Tools - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
- ���� �Ƚ������ EntityFramework ��ó�� �����̳ʸ� �̿��ϴ� EF Core Power Tools ��� ���α׷��� �ֽ��ϴ�. 
- Scaffold ������ StoredProcedure�� �������� �������� Ef Core powertools ������ EntityFramework��ó�� StoredProcedure�������� �����ɴϴ�. 