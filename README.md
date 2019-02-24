# VR-Projekt *Leaf Reality*

*LeafReality* entstand im Rahmen der AM2-Übung [Media Transformation – Interaktives Erzählen in VR](http://lehre.idh.uni-koeln.de/lehrveranstaltungen/wisem18/media-transformation-interaktives-erzahlen-in-vr/) im Wintersemester 2018/2019, einer Lehrveranstaltung des Instituts für Digital Humanitites der Universität zu Köln. 

Mitglieder der Projektgruppe: Kim Roland, Lukas Mönch, Anna Casters.

### Projektidee 
Bei *LeafReality* handelt es sich um eine VR-Installation. Sie beschäftigt sich mit Mark. Z. Danielewskis alternativen Raumkonzepten. Ausgewählte Teile seines Romans "*Das Haus -- House of Leaves*" wurden nach eigener Interpretation in einer virtuellen Umgebung umgesetzt, um die Erkundungstour des Hauptcharakters Navidson erlebbar zu machen. Das Hauptaugenmerk der **Medientransformation** richtet sich dabei auf die *Transmediation* (nach Lars Elleström), also die inhaltsbasierte Übertragung der Narration und die Abbildung einer Eigeninterpretation des *virtual space* durch 3D-Modelle.

<img src="Screenshots/LeafReality.png">

### Umsetzung
Zur Orientierung und Bewegung im dreidimensionalen Raum der Projektanwendung wurde ein *Reticle Pointer* selbst entwickelt, durch den die UserInnen mit der virtuellen Umgebung und ihren Objekten interagieren können. 
Dieser Pointer ist permanent in das Sichtfeld integriert und dient zur Auswahl der ebenfalls selbst konzipierten **Interaction targets**, die aus beweglichen *particles*, meist herunterfallenden *leaves*, bestehen und an Schlüsselpunkten innerhalb der VR-Umgebung erscheinen. Die Auswahl eines solchen *targets* erfolgt über die zentrierte Ausrichtung des Blicks bzw. Pointers auf das Ziel. Die schrittweise rote Färbung des Pointer-Inneren zeigt dabei die laufende Targetauswahl an; durch Wegschauen kann diese auch abgebrochen werden. Bei erfolgreicher Auswahl eines Interaktionspunktes bewegt sich der User/die Userin entweder im Rahmen einer Schritte-simulierenden Animation an die gewählte Stelle oder wird an einen unbekannten Punkt oder in einen neuen Raum teleportiert. Außerdem können durch die Auswahl auch Raumveränderungen und Szenenwechsel herbeigeführt werden. Zusätzlich haben die UserInnen an ausgewählten Stellen der virtuellen Erkundung die Möglichkeit, sich mit einem Fahrrad fortzubewegen (so wie auch Navidson).

Insgesamt können sich UserInnen innerhalb der virtuellen Umgebung immer frei umschauen und bekommen durch die *interaction targets* Hinweise zur Orientierung sowie verschiedene Möglichkeiten zur Interaktion und Fortbewegung. 

<img src="Screenshots/sleep.gif">

### Verwendete Technologien
Im Rahmen der technischen Umsetzung wurde verschiedene Software genutzt. Die Modelle zur Raumdarstellung wurden in **3ds Max** modelliert; darüber hinaus wurden einzelne Objekte mit **MagicaVoxel** erstellt. Diese sollen sich durch ihren besonderen Stil von der restlichen Umgebung abheben, da sie wichtige Gegenstände innerhalb der Geschichte darstellen. 

Mithilfe der Game-Engine **Unity** wurden alle 3D-Modelle zusammengeführt und mit ausgewählten Animationen sowie selbstgeschriebenen C#-Skripten verknüpft, um eine interaktive und dynamische VR-Umgebung zu entwickeln. Die VR-Funktionalität konnte dabei durch die Verwendung des Unity-kompatiblen und open source-zugänglichen Softwarepakets von [GoogleVR](https://github.com/googlevr/gvr-unity-sdk/releases) implementiert werden. Außerdem wurden [3D-Texturen](https://3dtextures.me) (ebenfalls open source) genutzt, um das Gefühl von Räumlichkeit innerhalb der VR-Umgebung während der Erkundung des *House of Leaves* zu unterstützen.
