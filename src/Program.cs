using RedisGraphDotNet.Client;

var redis = new RedisGraphClient("localhost", 6379);

const string deponia1 = "Deponia1";

await redis.DeleteGraph(deponia1);

// Start
await redis.Query(deponia1, "CREATE (:Start {name: 'Start'})");

// Rufus Zimmer
await redis.Query(deponia1, "CREATE (r:Room {name: 'RufusZimmer'})");

await redis.Query(deponia1, "MATCH (s:Start), (r:Room) WHERE s.name = 'Start' AND r.name = 'RufusZimmer' CREATE (s)<-[:EntryFrom]-(r)");

await redis.Query(deponia1, "CREATE (:Item {name: 'GruneSocke'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'RufusZimmer'}), (i:Item) WHERE i.name = 'GruneSocke' CREATE (r)-[:Contains]->(i)");

await redis.Query(deponia1, "CREATE (:Item {name: 'Liste'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'RufusZimmer'}), (i:Item) WHERE i.name = 'Liste' CREATE (r)-[:Contains]->(i)");

await redis.Query(deponia1, "CREATE (:Item {name: 'Oldose'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'RufusZimmer'}), (i:Item) WHERE i.name = 'Oldose' CREATE (r)-[:Contains]->(i)");

await redis.Query(deponia1, "CREATE (:Item {name: 'Schweissgerat'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'RufusZimmer'}), (i:Item) WHERE i.name = 'Schweissgerat' CREATE (r)-[:Contains]->(i)");

// Wohnbereich
await redis.Query(deponia1, "CREATE (r:Room {name: 'Wohnbereich'})");
await redis.Query(deponia1, "MATCH (z:Room), (w:Room) WHERE z.name = 'RufusZimmer' AND w.name = 'Wohnbereich' CREATE (z)-[:EntryFrom]->(w)-[:EntryFrom]->(z)");

await redis.Query(deponia1, "CREATE (:Item {name: 'ZahnbursteOpen'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'ZahnbursteOpen' CREATE (r)-[:Contains]->(i)");

await redis.Query(deponia1, "CREATE (:Item {name: 'ZahnbursteHidden'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'ZahnbursteHidden' CREATE (r)-[:Contains]->(i)");

await redis.Query(deponia1, "MATCH (o:Item), (h:Item) WHERE o.name = 'ZahnbursteOpen' AND h.name = 'ZahnbursteHidden' CREATE (o)<-[:Needs]-(h)");

await redis.Query(deponia1, "CREATE (:Item {name: 'Seitenschneider'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Seitenschneider' CREATE (r)-[:Contains]->(i)");

// create Thing Ofen in Wohnbereich
await redis.Query(deponia1, "CREATE (:Thing {name: 'Ofen'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (t:Thing) WHERE t.name = 'Ofen' CREATE (r)-[:Contains]->(t)");

await redis.Query(deponia1, "CREATE (:Item {name: 'Washmittel'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Washmittel' CREATE (r)-[:Contains]->(i)");

// create item PostmenstrualeMemo
await redis.Query(deponia1, "CREATE (:Item {name: 'PostmenstrualeMemo'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'PostmenstrualeMemo' CREATE (r)-[:Contains]->(i)");

// create item HeftigeMemo in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'HeftigeMemo'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'HeftigeMemo' CREATE (r)-[:Contains]->(i)");

// create item MistigeMemo in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'MistigeMemo'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'MistigeMemo' CREATE (r)-[:Contains]->(i)");

// create item ZickigeMemo in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'ZickigeMemo'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'ZickigeMemo' CREATE (r)-[:Contains]->(i)");

// create item NervigeMemo in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'NervigeMemo'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'NervigeMemo' CREATE (r)-[:Contains]->(i)");

// create item HaufenZettel from all the memos
await redis.Query(deponia1, "CREATE (:Item {name: 'HaufenZettel'})");
await redis.Query(deponia1, "MATCH (o:Item), (i:Item) WHERE o.name = 'HaufenZettel' AND i.name IN ['PostmenstrualeMemo', 'HeftigeMemo', 'MistigeMemo', 'ZickigeMemo', 'NervigeMemo'] CREATE (o)-[:CombinedFrom]->(i)");

// create item Gabel in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'Gabel'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Gabel' CREATE (r)-[:Contains]->(i)");

// create item BlaueSocke in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'BlaueSocke'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'BlaueSocke' CREATE (r)-[:Contains]->(i)");

// create item GelbeSocke in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'GelbeSocke'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'GelbeSocke' CREATE (r)-[:Contains]->(i)");

// Ofen needs the three socks
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Ofen' AND i.name IN ['GruneSocke', 'BlaueSocke', 'GelbeSocke'] CREATE (t)-[:Needs]->(i)");

// Ofen needs Gabel
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Ofen' AND i.name = 'Gabel' CREATE (t)-[:Needs]->(i)");

// create item Sockenpaar from Ofen
await redis.Query(deponia1, "CREATE (:Item {name: 'Sockenpaar'})");
await redis.Query(deponia1, "MATCH (s:Item), (t:Thing) WHERE s.name = 'Sockenpaar' AND t.name = 'Ofen' CREATE (s)-[:OutputFrom]->(t)");

// create item Topf in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'Topf'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Topf' CREATE (r)-[:Contains]->(i)");

// Ofen needs HaufenZettel
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Ofen' AND i.name = 'HaufenZettel' CREATE (t)-[:Needs]->(i)");
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Ofen' AND i.name = 'Schweissgerat' CREATE (t)-[:Needs]->(i)");
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Ofen' AND i.name = 'Topf' CREATE (t)-[:Needs]->(i)");
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Ofen' AND i.name = 'Washmittel' CREATE (t)-[:Needs]->(i)");

// create item Proviant in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'Proviant'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Proviant' CREATE (r)-[:Contains]->(i)");
// Proviant needs Oldose
await redis.Query(deponia1, "MATCH (p:Item), (i:Item) WHERE p.name = 'Proviant' AND i.name = 'Oldose' CREATE (p)-[:Needs]->(i)");

// create item Pompel in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'Pompel'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Pompel' CREATE (r)-[:Contains]->(i)");

// create item Mausefalle in Wohnbereich
await redis.Query(deponia1, "CREATE (:Item {name: 'Mausefalle'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'Wohnbereich'}), (i:Item) WHERE i.name = 'Mausefalle' CREATE (r)-[:Contains]->(i)");

await redis.Query(deponia1, "MATCH (p:Item), (m:Item) WHERE p.name = 'Pompel' AND m.name = 'Mausefalle' CREATE (p)<-[:Needs]-(m)");

// create item FalleMitKoder from Mausefalle and Proviant
await redis.Query(deponia1, "CREATE (:Item {name: 'FalleMitKoder'})");
await redis.Query(deponia1, "MATCH (f:Item), (m:Item), (p:Item) WHERE f.name = 'FalleMitKoder' AND m.name = 'Mausefalle' AND p.name = 'Proviant' CREATE (p)<-[:CombinedFrom]-(f)-[:CombinedFrom]->(m)");

// create item Zahnburste from FalleMitKoder and ZahnbursteHidden
await redis.Query(deponia1, "CREATE (:Item {name: 'Zahnburste'})");
await redis.Query(deponia1, "MATCH (z:Item), (f:Item), (h:Item) WHERE z.name = 'Zahnburste' AND f.name = 'FalleMitKoder' AND h.name = 'ZahnbursteHidden' CREATE (f)<-[:CombinedFrom]-(z)-[:CombinedFrom]->(h)");

// create Thing Koffer in RufusZimmer
await redis.Query(deponia1, "CREATE (:Thing {name: 'Koffer'})");
await redis.Query(deponia1, "MATCH (r:Room {name: 'RufusZimmer'}), (t:Thing) WHERE t.name = 'Koffer' CREATE (r)-[:Contains]->(t)");

// Koffer needs Seitenschneider
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Koffer' AND i.name = 'Seitenschneider' CREATE (t)-[:Needs]->(i)");
// Koffer needs Sockenpaar
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Koffer' AND i.name = 'Sockenpaar' CREATE (t)-[:Needs]->(i)");
// Koffer needs Proviant
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Koffer' AND i.name = 'Proviant' CREATE (t)-[:Needs]->(i)");
// Koffer needs Zahnburste
await redis.Query(deponia1, "MATCH (t:Thing), (i:Item) WHERE t.name = 'Koffer' AND i.name = 'Zahnburste' CREATE (t)-[:Needs]->(i)");

// create room HinterTonisHutte
await redis.Query(deponia1, "CREATE (:Room {name: 'HinterTonisHutte'})");
// HinterTonisHutte has EntryFrom Wohnbereich
await redis.Query(deponia1, "MATCH (r:Room {name: 'HinterTonisHutte'}), (r2:Room {name: 'Wohnbereich'}) CREATE (r)-[:EntryFrom]->(r2)-[:EntryFrom]->(r)");
// HinterTonisHutte needs Koffer
await redis.Query(deponia1, "MATCH (r:Room), (t:Thing) WHERE r.name = 'HinterTonisHutte' AND t.name = 'Koffer' CREATE (r)-[:Needs]->(t)");
