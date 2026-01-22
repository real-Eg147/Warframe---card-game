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

Ho aggiunto le altre due fazioni
Sto aggiungendo le armi, con le seguenti proprietà:
- Tipi di danno (danno base, critico, effetto, probabilità)
- Tipi di efffetti
- Identità (arma 1 tipo assalto, arma 2 tipo cecchino ecc...)

Come dovrebbe funzionare (per ora) il round? A console scegli il tipo di arma e si attacca in automatico
Serve capire il numero di attacchi (dipende dall'arma scelta) e il danno inflitto (quindi controllo su eventuali protezioni come armature e scudi, anche gli effetti elementali)

Aggiunto il controllo sulla resistenza del nemico (al danno ricevuto, gli viene sottratto un valore in base al valore dell'amatura)

Aggiunto il numero di colpi da poter infliggere in un solo turno