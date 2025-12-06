CALL C:\Dev\Factory\SetEnv.bat
runsub Release

MD C:\temp
RDMD /RM C:\temp\Release
RDMD /MD C:\temp\Release\out

C:\apps\Compress\Compress.exe ^
	Chroco\out\Chroco ^
	C:\temp\Release\out\Chroco.cmp-gz
C:\apps\Compress\Compress.exe ^
	GUIChroco\out\GUIChroco ^
	C:\temp\Release\out\GUIChroco.cmp-gz

sha512 /O ^
	C:\temp\Release\out\Chroco.cmp-gz ^
	C:\temp\Release\out\Chroco.cmp-gz.hash
sha512 /O ^
	C:\temp\Release\out\GUIChroco.cmp-gz ^
	C:\temp\Release\out\GUIChroco.cmp-gz.hash

SFCP /CDO ^
	Installer\out\Installer ^
	C:\temp\Release\out

SFCP /MD ^
	C:\temp\Release\out ^
	C:\temp\Release\ChunkRootCopier

z7 /C C:\temp\Release\ChunkRootCopier

START C:\temp\Release

TIMEOUT 2
