# WEffects – Mini Combat Simulator (Console C#)

Questo progetto è un **prototipo di simulatore di combattimento a turni** scritto in **C# (Console Application)**, ispirato a sistemi di danno con **armi, probabilità critiche, status effect ed armatura** (stile Warframe).

L'obiettivo del codice è **sperimentare la logica di combattimento**, non fornire ancora un'architettura finale o bilanciata.

---

## 🎯 Obiettivo del progetto

* Generare un **nemico** (attualmente Grineer)
* Generare un'**arma** con statistiche diverse
* Simulare uno o più **attacchi per turno**
* Applicare **riduzioni del danno** basate sull'armatura
* Preparare il terreno per **status elementali** (Fire, Electric, ecc.)

---

## 🧠 Flusso generale del programma

1. Avvio del programma (`Main`)
2. Scelta del **tipo di nemico**
3. Creazione dell'istanza del nemico
4. Scelta dell'**arma**
5. Impostazione delle statistiche dell'arma
6. Esecuzione di N attacchi in base all'arma
7. Calcolo del danno finale
8. Stampa dello stato del nemico

---

## 📁 Struttura dei namespace e classi

### `namespace WEffects`

Contiene la logica principale del combattimento.

---

### 🟦 `Program`

Classe principale con il metodo `Main`.

Responsabilità:

* Input utente (scelta nemico e arma)
* Creazione degli oggetti
* Gestione dei turni di attacco
* Output finale dei valori

Esempio:

* Un fucile d'assalto esegue **3 attacchi per turno**
* Una pistola **2 attacchi**

---

### 🟥 `Grineer`

Rappresenta un nemico di tipo Grineer.

Proprietà:

* `Health`
* `Armor`
* `Shield`

Override di `ToString()` per stampare lo stato del nemico:

```
Grineer[0]: 18, 25, 0
```

⚠️ Nota: l'`id++` nel `ToString()` incrementa ogni volta che stampi — comportamento temporaneo.

---

### 🟨 `Weapons`

Definisce le **statistiche di un'arma**.

Attributi:

* `BaseDamage`
* `CritDamage`
* `CritChance`
* `StatusChance`

Metodo principale:

* `Damage(int id_weapon)` → assegna le statistiche in base all'arma selezionata

Esempio:

* Fucile a pompa: danno alto, pochi colpi, status elevato
* Fucile di precisione: critico molto alto

---

### 🟩 `Round`

Gestisce l'**attacco vero e proprio**.

Metodo:

* `Attack(List<Grineer>)`

Logica attuale:

* Se `Armor > 20` → danno ridotto del 10%
* Altrimenti → danno pieno

```csharp
Health = Health - (BaseDamage * 0.90)
```

⚠️ Attualmente `BaseDamage

## Sistema di Combattimento – Stato Attuale

Sono state integrate ulteriori **due fazioni** nel sistema di gioco.

È in fase di sviluppo il **sistema delle armi**, strutturato secondo le seguenti proprietà:

### Proprietà delle Armi

- **Tipologie di danno**
  - Danno base
  - Danno critico
  - Effetti speciali
  - Probabilità di attivazione degli effetti
- **Tipologie di effetti**
  - Effetti elementali
  - Effetti di stato
- **Identità dell’arma**
  - Definisce il ruolo dell’arma (es. Assalto, Cecchino, ecc.)

---

## Funzionamento del Round (Versione Attuale)

Durante ogni round, il giocatore seleziona tramite **input da console** il tipo di arma da utilizzare.  
L’attacco viene quindi **eseguito automaticamente** dal sistema.

Il sistema di combattimento gestisce i seguenti aspetti:

- **Numero di attacchi per turno**
  - Dipende dall’arma equipaggiata
- **Calcolo del danno inflitto**
  - Verifica delle protezioni del bersaglio (armature, scudi)
  - Applicazione di effetti elementali o speciali (da definire!)
  - Calcolo dei danni critici (da definire!)

---

## Sistema di Difesa e Resistenze

È stato implementato un **sistema di resistenza del nemico**, che riduce il danno ricevuto in base al valore dell’armatura o della protezione attiva.

- Il danno finale viene calcolato con la seguente formula [DANNO BASE - (DANNO BASE x RESISTENZA)]

Esempio:
15-(15x0,6) = 15-9 = 6 

- Il sistema è estendibile per resistenze specifiche (es. fuoco, elettricità, corrosione)

---

## Limiti e Supporto Multi-Bersaglio

- È stato introdotto un **limite massimo di colpi infliggibili per turno**
- Il sistema ora supporta il **combattimento contro più avversari contemporaneamente** ma è ancora limitato

---

## Note di Progettazione

- Il sistema è progettato per essere **modulare ed estendibile**
- Le regole di calcolo del danno possono essere facilmente adattate a:
  - PvE
  - PvP
  - PvPvE asimmetrico
