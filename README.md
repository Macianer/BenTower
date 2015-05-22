# BenTower
Hallo Benedikt, ich weiss, dass Du dich für Computerspiele interessierst. Was hältst du davon, dein eigenes Spiel zu erschaffen? Mir ist bewusst das der Anfang nicht leicht ist. Aber heutzutage ist die Entwicklung eines eigenen Spieles so einfach wie nie. Damit dir der Einstieg leichter fällt, habe ich ein kleines Spiel für dich gebaut, quasi als ein zusätzliches Jugendweihe-Geschenk. 
Das Spiel heisst „BenTower“!  

Ich hoffe du probierst das Spiel mal aus.
Hier ist eine fertige Version für das Windows Betriebssystem [BenTower_win32] (http://meissner-ronny.de/BenTower_win32.zip), ich hoffe es funktioniert, da ich derzeit kein Windows installiert habe und somit das Spiel nicht testen konnte. 

## Das Spiel:
Das Prinzip des Spiels ist recht einfach. Du musst den Turm in der Mitte beschützen. In dem du angreifende Feinde vernichtest. Ganz simpel betrachtet ist das hier verwendete Spielprinzip eine Form des Types: [TowerDefense] (http://de.wikipedia.org/wiki/Tower_Defense). Beispielsweise findet man dieses Prinzip auch bei Spielen wie „Clash of Clans“. 

Das Spiel gewinnt man, indem der Spieler drei Gegner trifft. Die Gegner sind die roten Kugeln, die sich stetig den Turm nähern. Wenn eine rote Kugel den Turm zu nahe kommt, ist das Spiel beendet. Um die roten Kugeln zu treffen, muss der Spieler die „Space“-Taste auf der Tastatur drücken. 

### Steuerung
Mit den Pfeil-Tasten für links und rechts drehst du den Turm. Mit der Space-Taste schiesst der Spieler. Dabei bestimmt die Länge des Gedrückthaltens die Intensität des Schusses. Je Stärke die Intensität, umso weiter kann der Spieler schiessen. 

## Installation und Einrichtung
Zum Erstellen des Spiels benötigst du die Programme Unity3D und Blender. Unity3D ist eine Spiele-Engine, die für den Heimgebrauch freiverfügbar ist. Blender verwende ich gerne um 3D Modelle zu erstellen. Blender ist komplett Open Source. Alle 3D Elemente sind mit Blender erstellt. 

### Benötigte Programme
Folgende Programme werden zum Bauen des Spiels benötigt:
* [Unity3D – Personal Edition] (http://unity3d.com/get-unity)
* [Blender] (https://www.blender.org/download/) 

### Installation der Programme
Hole dir die genannten Programme von den jeweiligen Webseiten und installiere diese. Um das Spiel auszuführen, brauchst du eigentlich nur Unity3d. Blender wird nur benötigt für die Bearbeitung der 3D-Modelle.
Wichtig für die Installation von Unity3D ist die Registrierung, hierbei muss unbedingt die „Personal Edition“ ausgewählt werden. Zusätzlich muss man sich mit seiner Emailadresse und Passwort registrieren. Aber keine Sorge du kannst eigentlich nicht viel falsch machen. Sobald du aufgefordert wirst Kreditkartendaten einzutragen, dann hast du etwas falsch gemacht ;)

Die Installation von Blender ist sehr einfach und muss nicht weiter erklärt werden. 

### Installation des Spieles 

1. Lade Dir das Spiel unter diesem Link: https://github.com/ronnymeissner/BenTower/archive/master.zip
Oder du klickst auf „Download ZIP“ auf dieser Github-Seite  (https://github.com/ronnymeissner/BenTower).
2. Entpacke BenTower-master.zip auf den Desktop oder wo du willst. 
3.Starte Unity3d.
4. Im Programm Unity3d klickst du oben in der Menüleiste auf „Open Project ...“.
5.  Anschliessend erscheint ein Dateidialogfenster, wo du den entpackten Ordner "BenTower-master" auswählen und öffnen musst.
6. Fertig! Das Projekt ist nun geladen. 

![Projekt](https://github.com/ronnymeissner/BenTower/blob/master/Assets/Help/oeffnen_in_unity.png "Projekt Öffnen in Unity3D")

### Projekt bauen und ausführen

Um das Projekt zu testen, kann man die Szene innerhalb von Unity3d abspielen bzw. spielen. 

![Projekt](https://github.com/ronnymeissner/BenTower/blob/master/Assets/Help/starten_in_unity.png "Projekt Starten in Unity3D")

#### Projekte bauen
Weiterhin kannst du auch das Projekt für verschiedene Plattformen bauen. Dafür muss man in der Menuleiste auf File->Build&Run klicken (siehe nachfolgende Abbildung). 

![Projekt](https://github.com/ronnymeissner/BenTower/blob/master/Assets/Help/bauen_und_ausfuehren_1.png "Projekt bauen")
Anschliessend kann man in der Ansicht Build-Setting (siehe nachfolgende Abbildung) die jeweilige Plattform wählen und das Projekt bauen.

![Projekt](https://github.com/ronnymeissner/BenTower/blob/master/Assets/Help/bauen_und_ausfuehren_2.png "Projekt bauen 2")
## Ordner und Komponenten
![Ordner](https://github.com/ronnymeissner/BenTower/blob/master/Assets/Help/ordnerstruktur.png "Ordner Struktur")

<ol>
<b>BenTower Ordnerstruktur:</b>
<ol>
<li>Assets</li>
<ol>
<li><b>3d_models</b> Alle 3D-Modelle für den Turm und alle anderen 3D-Elemente sind hier gespeichert.</li>
<li><b>Materials</b> Unter diesem Ordner sind alle Materialien für die Oberflächen der 3D-Modelle gespeichert.</li>
<li><b>Resources</b> Hier werden die „Prefabs“ gespeichert. „Prefabs“ sind vorkonfigurierte Szenen-Objekte, welche bereits mit Skript-Objekten oder andere Objekten ausgestattet sind.</li>
<li><b>Scene</b> In diesem Ordner befinden sich alle Szenen.</li>
<li><b>Scripts</b> Die Skripte oder Programmier-Elemente befinden sich in diesem Ordner.</li>
<li><b>Textures</b> Die Bilddateien für das Spiel kannst du hauptsächlich hier finden.</li>
</ol>
<li><b>ProjectSettings</b> Hier werden Einstellung von Unity3D gespeichert. </li>
</ol></ol>

### Szenen
In Unity3d werden verschiedene Level oder andere Abschnitte innerhalb des Projektes als „Szene“ bezeichnet. Eine Szene kann man sich als Ansammlung von Sounds, 3D-Modelle, Grafiken, Skripten usw. vorstellen. 
Das Projekt „BenTower“ umfasst insgesamt vier Szenen: Start, Spiel, Ende, HappyEnd.

#### Start-Szene
Die Start-Szene wird als Erstes geladen, wenn das Spiel gestartet wird. 
Innerhalb der Start-Szene hat der Spieler die Möglichkeit das eigentliche Spiel zu starten.
Die Szenendaten liegen in dem Ordner Assets->Scene.
 
#### Spiel-Szene
Die Spiel-Szene beinhaltet das eigentliche Spiel. Hier muss der Spieler die gegnerischen Elemente vernichten.

#### Ende-Szene
Die Ende-Szene wird gestartet, wenn der Spieler das Spiel verliert.

#### HappyEnd-Szene
Die HappyEnd-Szene wird gestartet, wenn der Spieler das Spiel gewinnt.

### Skripte
Skripte sind diejenigen Elemente, welche die gesamte Logik und das Verhalten beeinflussen.
Das Schreiben der Skripte nennt man programmieren. Mithilfe der Programmierung wird in Unity3D der Spielablauf, die Steuerung und andere Komponenten beeinflusst. 
In Unity3d kann man mehrere Skriptsprachen verwenden. Unity3d erlaubt das Programmieren mit C-Sharp und Javascript. Ich persönlich arbeite lieber mit C-Sharp (C#) statt Javascript.
Die Skriptdateien liegen in dem Ordner Assets->Scripts. 

Um die Skripte zu bearbeiten, muss man innerhalb von Unity3d auf ein Skript-Objekt klicken. Anschliessend wird ein extra Programm zum Bearbeiten der Skripte gestartet. Unity3d verwendet stets die Programmier-Umgebung MonoDevelop zum Bearbeiten der Skripte. MonoDevelop wird automatisch bei der Installation von Unity3d mit installiert.

Soweit es mir möglich war, sind alle Komponenten innerhalb der Skripte auf Deutsch geschrieben.
Einige Abschnitte sind teilweise sehr komplex, was sich aber nicht vermeiden ließ. Um die schwierigsten Stellen zuverstehen benötigt man sicherlich Schulwissen von Klasse 10 und höher.
Aber das sollte nicht das Problem sein. 
    
Nun werde ich noch kurz auf die grobe Funktion der Skripte eingehen. 

#### Skript - GeschossAktionen.cs
Dieses Skript ist verknüpft mit dem 3D-Modelle der abgeschossenen Kugel. Es sorgt dafür, dass Kollisionen mit dem Untergrund und Gegner behandelt werden.

#### Skript – IntroManager.cs
Das IntroManager-Skript wird für die folgenden Szenen genutzt: Start, Ende und HappyEnd. Es steuert das Starten eines neuen Spieles und die Animationen innerhalb der Szenen.	

#### Skript – ObjektAktionen.cs
Die ObjektAktionen werden für das Klicken auf das „Start“ 3D-Modell verwendet. 

#### Skript – SzenenManager.cs
Innerhalb des SpielManagers sind die Aktionen zum Laden aller Szenen gespeichert.

#### Skript – SpielManager.cs
Zu guter Letzt kommt das umfangreichste Skript von „BenTower“. Das SpielManager-Skript ist das Herzstück des eigentlichen Spiels. Dieses Skript kümmert sich um die Steuerung des Spiels. Hier werden die gegnerischen Objekte erzeugt. Alle Animationen werden von hieraus beeinflusst.

## Aufgaben
Leider bin ich mit dem Spiel noch nicht fertig. Was hältst du davon, das Spiel weiter zu entwickeln?
Im Folgenden sind ein paar kleine Aufgaben zur Übung aufgeführt. Probier diese zu lösen!

### Primäre Aufgaben (einfache Schwierigkeitsstufe):
* Ändere die Anzahl der angreifenden Gegner.
* Ändere die Anzahl der zutreffenden Gegner, um das Spiel zu gewinnen.
* Ersetze das Platzhalterbild mit einem Bild von Dir. 

### Zukünftige Aufgaben (erhöhte Schwierigkeitsstufe):
* Die Anzeige-Elemente wie die Anzahl der getroffenen Gegner oder die Anzeige der Schussstärke sind nicht richtig positioniert.
* Ich finde es fehlt an Musik und Sound. Für das Spiel wäre eine Hintergrundmusik nicht schlecht.  
Außerdem bräuchten wir einen Sound für die Kanone. Natürlich fehlen dann noch Sounds für den Fall, dass ein Gegner getroffen wird oder der Schuss daneben ging. 

## Fragen und Wünsche
Wenn du Fragen hast oder du an einer Stelle nicht weiterkommst, melde dich einfach bei mir. 
Oder du hast Ideen für ein eigenes Spiel? Gerne helfe ich dir bei der Umsetzung. 
Schreib mir einfach per Email: developer@meissner-ronny.de

Weiterhin gibt es für Unity3d und für Blender viele Lehrvideos auf Youtube. Es gibt auch mehrere deutschsprachige Videos. 

