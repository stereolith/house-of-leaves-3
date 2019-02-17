# VR-Projekt *Leaf Reality*

*LeafReality* entstand im Rahmen der AM2-Übung [Media Transformation – Interaktives Erzählen in VR](http://lehre.idh.uni-koeln.de/lehrveranstaltungen/wisem18/media-transformation-interaktives-erzahlen-in-vr/) im Wintersemester 2018/2019, einer Veranstaltung des Instituts für Digital Humanitites der Universität zu Köln. 

Mitglieder der Projektgruppe: Kim Roland, Lukas Mönch, Anna Casters.

### Projektidee 
Bei *LeafReality* handelt es sich um eine VR-Installation. Sie beschäftigt sich mit Mark. Z. Danielewskis alternativen Raumkonzepten. Ausgewählte Teile seines **House of Leaves** wurden nach eigener Interpretation in einer virtuellen Umgebung umgesetzt, um die Erkundungstour des Hauptcharakters Navidson erlebbar zu machen. Das Hauptaugenmerk der **Medientransformation** richtet sich dabei auf die Transmediation, also die inhaltsbasierte Übertragung der Narration und die Abbildung einer Eigeninterpretation *virtual space* (Elleström) durch 3D-Modelle.

<img src="Screenshots/TowerScene.png" width="400"> <img src="Screenshots/SpiralStairs.png" width="400">

### Umsetzung
Zur Orientierung und Bewegung im dreidimensionalen Raum der Projektanwendung wurde ein *Reticle Pointer* selbst entwickelt, durch den die UserInnen mit der virtuellen Umgebung und ihren Objekten interagieren können. 
Dieser Pointer ist permanent in das User-Sichtfeld integriert und dient zur Auswahl der ebenfalls selbst konzipierten **Interaction targets**, die aus herunterfallenden *leaves* bestehen und an Schlüsselpunkten innerhalb der VR-Umgebung erscheinen. Die Auswahl eines solchen *targets* erfolgt über die zentrierte Ausrichtung des Blicks bzw. Pointers auf die Blätter. Die schrittweise rote Färbung des Pointer-Inneren zeigt dabei die laufende Punktauswahl an; durch Wegschauen kann diese auch abgebrochen werden. Bei erfolgreicher Auswahl eines Zielpunktes bewegt sich der/die User/in entweder im Rahmen einer Schritte-simulierenden Animation an die gewählte Stelle oder wird an einen unbekannten Punkt oder einen neuen Raum teleportiert. Zusätzlich hat der User/die Userin die Möglichkeit, sich mit einem Fahrrad fortzubewegen. 

Insgesamt kann sich der Spieler innerhalb der virtuellen Umgebung immer frei umschauen und bekommt durch die *interaction targets* Hinweise zur Orientierung sowie verschiedene Möglichkeiten zur Interaktion und Fortbewegung. 

### Verwendete Technologien
Im Rahmen der technischen Umsetzung wurde verschiedene Software genutzt. Die Modelle zur Raumdarstellung wurden in **3ds Max** modelliert; darüber hinaus wurden einzelne Objekte mit **MagicaVoxel** erstellt. Diese sollen sich durch ihren besonderen Stil von der restlichen Umgebung abheben, da sie wichtige Gegenstände innerhalb der Geschichte darstellen. 

Mithilfe der Game-Engine **Unity** wurden alle Objekte mit den entsprechenden Animationen und dazugehörigen Skripten verknüpft, um die beschriebene interaktive VR-Welt zu entwickeln. Außerdem wurden open-source zugängliche [3D-Texturen](https://3dtextures.me) genutzt, um das Gefühl von Dreidimensionalität innerhalb der VR-Umgebung und während der Erkundung des *House of Leaves* zu unterstützen.


