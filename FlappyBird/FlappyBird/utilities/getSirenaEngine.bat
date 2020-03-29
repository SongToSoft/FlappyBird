git clone https://github.com/SongToSoft/SirenaEngineMG
cd ..
rmdir /Q /S SirenaSrc
mkdir SirenaSrc
cd SirenaSrc
xcopy /s "..\utilities\SirenaEngineMG\SirenaEngineMG\SirenaEngineMG\SirenaSrc"
cd ..
rmdir /Q /S Content
mkdir Content
cd Content
xcopy /s "..\utilities\SirenaEngineMG\SirenaEngineMG\SirenaEngineMG\Content"
rmdir /Q /S "..\utilities\SirenaEngineMG"