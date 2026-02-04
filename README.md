# WEffects – Mini Combat Simulator (Console C#)

Questo progetto è un **prototipo di simulatore di combattimento a turni** scritto in **C# (Console Application)**, ispirato a sistemi di danno con **armi, probabilità critiche, status effect ed armatura** (stile Warframe).

L'obiettivo del codice è **sperimentare la logica di combattimento**, non fornire ancora un'architettura finale o bilanciata.

Perlopiù il progetto ha come scopo quello di "giocare" con le classi in C#, migliorandomi in programmazione OOP, mantenimento del codice e altro ancora...

---

## 🎯 Obiettivo del progetto

* Generare uno o più **nemici** (attualmente Grineer, Corpus e Infested)
* Generare una o più **armi** con statistiche diverse
* Simulare uno o più **attacchi per turno**
* Applicare **riduzioni del danno** basate sull'armatura e scudi
* Preparare il terreno per **status elementali** (Fire, Electric, ecc.)

---

## Nemici

Prendendo ispirazione dal videogioco Warframe, ho deciso di implementare il sistema di **Fazioni**. Nel mio progetto esistono tre fazioni, che sono:
* Grineer: hanno sempre un valore di **SALUTE** e **ARMATURA**
* Corpus: **SALUTE** e **SCUDI**
* Infested **SALUTE**

### Statistiche (salute, armature e scudi)
Per quanto riguarda le statistiche come la SALUTE, l'ARMATURA e gli SCUDI ho deciso di renderli valori di tipo double (per un codice più versatile e manutenibile nel futuro).
Inoltre, le statistiche non verranno aggiunte manualmente da me, ma ho creato una **struct** che mi ha permesso di generare questi valori in un range casuale da me scelto.
E questa logica vale per ogni generazione di ogni nemico di ogni fazione.
<img width="1387" height="464" alt="image" src="https://github.com/user-attachments/assets/01446015-3ed2-4d87-892c-4fe7b8ec5f8c" />
<img width="1151" height="637" alt="image" src="https://github.com/user-attachments/assets/c87d07fe-2acc-426b-9d38-e245e924d649" />

Ma come interagiscono con i **danni** ricevuti?
La salute come gli scudi sono valori che non ha apportano modifiche al danno in arrivo. Perciò se il danno che arriva al nemico è 2 la salute scende di 2 (ovviamente se la salute arriva a 0 il nemico è sconfitto, ma bisogna azzerargli gli scudi prima di fargli danno alla salute).
L'armatura è una resistenza al danno che apporta modifiche. Ho utilizzato la seguente formula per calcolare la resistenza al danno:

--> DANNO CON ARMATURA = DANNO - (DANNO * ARMATURA) 
poi 
--> SALUTE NEMICA = SALUTE NEMICA - DANNO CON ARMATURA

esempio pratico

--> valore_non_ancora_conosciuto = 5 - (5 * 0,2) --> risultato = 4
--> 20 = 20 - 4 --> risultato 16

Nella formula si evince che il danno in arrivo sia 5, ma quello che riceve il nemico è 4, perchè ha l'armatura 

---

## Effetti elementali

Nel progetto verrà aggiunta la possibilità di applicare un effetto di stato ai nemici.
Un effetto di stato (o elementale) è un parametro che altera il danno inflitto ai nemici.
Può influire su salute, armature e scudi, cambiandone il valore. Un singolo effetto può persistere per più turni.

Gli effetti elementali di base si dividono in:
* Fuoco: dimezza permanentemente l'armatura nemica, e applica danno nel tempo (ogni nuovo turno il nemico subisce danno senza sprecare un'azione di attacco)
* Elettrico: applichi +100% di danno agli scudi nemici
* Tossina: dopo aver attaccato un nemico, al prossimo turno tutti gli altri nemici subiscono il 25% del danno che hai inflitto
* Ghiaccio: quando applicato, il nemico resterà fermo per un turno

Mentre gli effetti elementali combinati sono i seguenti:
* Corrosivo (tossina + elettrico): quando applicato, sottrai il 26% all'armatura nemica per tre turni (si accumula fino a max di 80%)
* Radiazione (fuoco + elettrico): quando applicato, il nemico attaccherà un suo alleato per un turno
* Gas (fuoco + tossina): quando applicato, tutti i nemici subiranno il 50% del danno che gli hai inflitto per tre turni
* Virale (ghiaccio + tossina): quando applicato, solo la salute nemica subisce un danno extra pari al 100% del tuo danno base per due turni. Si accumula fino a +325%
* Esplosivo (ghiaccio + fuoco): quando applicato, tutti i nemici subiscono il 30% del tuo danno base. Se accumulato per 10x il danno sarà del 300%
* Magnetico (ghiaccio + elettrico): quando applicato, solo lo scudo nemico subisce un danno extra pari al 100% del tuo danno base. Si accumula fino a +325%

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


  4/02/2026
- In Factions ho modificato l'override string per far si che quando mi vengano mostratati i parametri dei nemici tipo SALUTE, non mi mostri 48,7428875 ma 48,7 (solo un numero dopo la virgola)
- Ho modificato la logica della generazione dei nemici per mescolarla meglio con li mio codice (prima i nemici si sovrascrivevano a vicenda nel momento della loro generazione, adesso vengono aggiunti uno dopo l'altro come doveva essere all'inizio)
- Modificato il modo in cui vengono visualizzati i nemici in Program.cs riga 107 (adesso vengono mostrati tutti i nemici insieme alle loro caratteristiche)
