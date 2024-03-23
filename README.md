## Projekt: Big Speech VR - VR Präsentation Simulator

## Einleitung
Diese technische Dokumentation bietet einen umfassenden Überblick über das Semesterprojekt "Big Speech VR", einen VR-Präsentationssimulator, entwickelt von Jason Leuschner und Lasse Knodt. Das Projekt zielt darauf ab, die Präsentationsfähigkeiten der Nutzer in einem virtuellen Umfeld zu verbessern, indem sie praktische Übungen durchführen und sofortiges Feedback erhalten.

Das Spielprinzip besteht darin, dass die Nutzer ihre eigene Präsentation im PNG-Format und gegebenenfalls ihre Stichpunkte als TXT importieren können. Nach Abschluss des Tutorials können sie eine der importierten Präsentationen auswählen und mit den gewünschten Features starten. Zu den wählbaren Features gehören das Pulse-Tracking (mit der HypeRate Smartwatch App), das Voice-Tracking (Erkennung von Füllwörtern mit wit.ai) und ein animierties NPC Publikum für live Feedback. Am Ende der Präsentation wird eine Übersicht der aufgezeichneten Daten angezeigt. Der Nutzer hat dann auch die Möglichkeit, seine Präsentation mit den vorherigen Versuchen zu vergleichen.

## Eigenleistung

### 3D-Modelle
#### Fahrstuhl
- Alle Modelle im Fahrstuhl, einschließlich des Fahrstuhls, der Tür, der Lampe und des Menüs, wurden von uns erstellt.

#### Studio und Tutorial
- Vordere Tribüne ohne Stühle
- Hintere Tribüne
- Bühne
- Leinwand
- Scheinwerfer
- Teleprompter
- Getränkebecher

#### Handmenü
- Alle Hand-Tracking-Gesten außer die Point Hand Shape wurden von uns erstellt.

### Importiert
- Die NPC's und Poses wurden nicht von uns erstellt, jedoch sind die Animation Controller und dazugehörigen Skripte von uns.

### Skripte
#### Eigenleistung
- Alle Skripte im Ordner "Recources/Scripts", darunter:
  - Main: Verantwortlich für das Steuern von Tracking, Szenen und Spielverlauf.
  - PresentationDataHandler: Auswertung von Daten wie Puls, Füllwörter, Stichpunkte und Abspeichern als JSON.
  - NPCReaction: Steuerung der Animationen und Sounds
  - CountAehms: Zählen der Füllwörter mit wit.ai.
  - PresentationOnLeinwand: Importieren von eigenen Präsentationen ins Spiel und Steuerung der nächsten Folie.
  - Elevator und ElevatorAnimation: Verantwortlich für die Fahr-Animation sowie Anzeigen und Laden von Präsentationen.

#### Importiert
- [HypeRate](https://www.hyperate.io/#1)-Pulstracking-Socket und Standard XR-Skripte.

### Packages
- OpenXR
- XR Core Utilities
- XR Hands
- XR Interaction Toolkit
- VR Keyboard - XRI Poke & Hands Support
- HypeRate
- wit.ai
- ProBuilder
- Editor Coroutines
- TextMeshPro


### Sounds
- Alle Sounds stammen von freesound.org.
- Die Tutorial-Stimme wurde mit narakeet.com generiert.

### Texturen
- Texturen wie Holzboden, Teppich oder Metall wurden mithilfe von heruntergeladenen Bildern erstellt.

## SW-Dokumentation

### Fehler und Besonderheiten
- Funktionen für Puls und Voice umgesetzt und eingepflegt
- Es gab Probleme bei dem Benutzen von der Meta SDK und OpenXR. Wir haben die Hände und Handgesten sowie Interaction mit OpenXR verbunden. Leider kann ohne die Meta SDK nicht das Puls Tracking und Voice Tracking aktiviert werden, da die Daten nicht bei der Brille ankommen. Durch das deaktivieren von OpenXR und aktivieren von Oculus gibt es leider kein Handtracking. Es gibt noch eine weitere Build, die da ist um das Handtracking auszuprobieren. Leider ist das auch sehr kurz vor der Abgabe aufgefallen deshalb gibt es noch zwei Tutorials.

### Klassendiagramm
![Klassendiagramm_Uebersicht](https://hackmd.io/_uploads/SyeTYJX3p.png)
![Klassendiagramm_1](https://hackmd.io/_uploads/Byp6KJ7nT.png)
![Klassendiagramm_2](https://hackmd.io/_uploads/Bk66Fk72p.png)
![Klassendiagramm_3](https://hackmd.io/_uploads/BJppFy7np.png)
![Klassendiagramm_4](https://hackmd.io/_uploads/r1p6tyXna.png)
![Klassendiagramm_5](https://hackmd.io/_uploads/rypptymn6.png)

### Aktivitätsdiagramm
![Aktivitätsdiagramm](https://hackmd.io/_uploads/Skyyc1mha.png)

### Sequenzdiagramm
![Sequenzdiagramm](https://hackmd.io/_uploads/BkDAFkQha.png)



