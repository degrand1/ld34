@REM if your unity editor path differs, either change it here (and do not check in your changes),
@REM or set it in your own build script and @call this script from your build script
@if defined UNITYEDITOR goto :skipSetDefaultUnityPath
@set UNITYEDITOR="E:\Unity\Editor\Unity.exe"

:skipSetDefaultUnityPath
@set WD=%cd%
@set DIST=Play
@if not exist %DIST% mkdir %DIST%
%UNITYEDITOR% -quit -batchMode -nographics -projectPath "%WD%\JumpStone" -buildTarget web -buildWebPlayer "%WD%\%DIST%"

git add %DIST%
git commit


git subtree push --prefix %DIST% origin gh-pages
