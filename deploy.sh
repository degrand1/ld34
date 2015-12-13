UNITYEDITOR=/Applications/Unity/Unity.app/Contents/MacOS/Unity

WD=`pwd`
DIST=Play

mkdir -p $WD/$DIST

$UNITYEDITOR -quit -batchMode -nographics -projectPath $WD/JumpStone -buildTarget web -buildWebPlayer $WD/$DIST

git add $DIST
git commit


git subtree push --prefix $DIST origin gh-pages
