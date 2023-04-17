# EF Core 도움!!

## dotnet ef core 설치 명령어 
```powershell
dotnet tool install --global dotnet-ef
```

## ef core Migration 명령어 
```
dotnet ef migrations add BingoWord2
```
- BingoWord2는 Migration버전 명칭으로 중복되지않게만 지정 할 것
- 위 명령어 실행시 포함된 테이블 클래스에 따라서 마이그레이션 코드 파일을 생성해줍니다.
## Migration 실행 명령어
```
dotnet ef database update
```
- 위 명령어 실행시 Migration 코드대로 Db에 적용합니다.
## Custom Class를 Migration 대상에 포함시키고 싶다면..
```
public DbSet<BingoWord> BingoWords { get; set; }
```
- 위 형태와 같이 DbContext를 상속받는 클래스파일에 넣어줍니다. 
## 기존 Db => Class 하고 싶으면 ?
```
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=MyPassword881512;database=myDb;" Pomelo.EntityFrameworkCore.MySql 
```
- 위 Pomelo.EntityFrameWorkCore.MySql 은  MySql사용시 쓰는것 입니다.  SqlServer는 Microsoft.EntityFrameworkCore.SqlServer 를 지정하시면 됩니다.  (패키지 이름)

- 스캐폴드를 더 편하게 하고싶으면 ? 
[EF Core Power Tools - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
- 저도 안써봤지만 EntityFramework 때처럼 디자이너를 이용하는 EF Core Power Tools 라는 프로그램이 있습니다. 
- Scaffold 에서는 StoredProcedure는 가져가지 못하지만 Ef Core powertools 에서는 EntityFramework때처럼 StoredProcedure정보까지 가져옵니다. 
