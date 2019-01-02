$src_dir=Read-Host
$test_dir=$src_dir + ".TEST"

mkdir $src_dir
cd $src_dir

mkdir $src_dir
mkdir $test_dir
dotnet new sln

$mk_file = $src_dir + ".md"
touch $mk_file

cd $src_dir
dotnet new classlib
cd ..
$src_csproj = $src_dir + "/" + $src_dir + ".csproj"
dotnet sln add $src_csproj

cd $test_dir
dotnet new mstest
dotnet add reference "../" + $src_csproj
nuget install ChainingAssertion
cd ..
$test_csproj = $test_dir + "/" + $test_dir + ".csproj"
dotnet sln add $test_csproj

