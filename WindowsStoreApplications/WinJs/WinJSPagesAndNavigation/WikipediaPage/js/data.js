(function () {
    "use strict";

    var list = new WinJS.Binding.List();
    var groupedItems = list.createGrouped(
        function groupKeySelector(item) {
            return item.group.key;
        },
        function groupDataSelector(item) {
            return item.group;
        }
        );

    // TODO: Replace the data with your real data.
    // You can add data from asynchronous sources whenever it becomes available.
    generateSampleData().forEach(function (item) {
        list.push(item);
    });

    WinJS.Namespace.define("Data", {
        items: groupedItems,
        groups: groupedItems.groups,
        getItemReference: getItemReference,
        getItemsFromGroup: getItemsFromGroup,
        resolveGroupReference: resolveGroupReference,
        resolveItemReference: resolveItemReference
    });

    // Get a reference for an item, using the group key and item title as a
    // unique reference to the item that can be easily serialized.
    function getItemReference(item) {
        return [item.group.key, item.title];
    }

    // This function returns a WinJS.Binding.List containing only the items
    // that belong to the provided group.
    function getItemsFromGroup(group) {
        return list.createFiltered(function (item) {
            return item.group.key === group.key;
        });
    }

    // Get the unique group corresponding to the provided group key.
    function resolveGroupReference(key) {
        for (var i = 0; i < groupedItems.groups.length; i++) {
            if (groupedItems.groups.getAt(i).key === key) {
                return groupedItems.groups.getAt(i);
            }
        }
    }

    // Get a unique item from the provided string array, which should contain a
    // group key and an item title.
    function resolveItemReference(reference) {
        for (var i = 0; i < groupedItems.length; i++) {
            var item = groupedItems.getAt(i);
            if (item.group.key === reference[0] && item.title === reference[1]) {
                return item;
            }
        }
    }

    // Returns an array of sample data that can be added to the application's
    // data list. 
    function generateSampleData() {
        var itemDescription = "Item Description: Pellentesque porta mauris quis interdum vehicula urna sapien ultrices velit nec venenatis dui odio in augue cras posuere enim a cursus convallis neque turpis malesuada erat ut adipiscing neque tortor ac erat";
        var groupDescription = "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante";

        var historyOfAuroraTheoriesContent = "<p>Multiple superstitions and obsolete theories explaining the aurora have surfaced over the centuries.</p><ul><li><a href=\"/wiki/Seneca_the_Younger\" title=\"Seneca the Younger\">Seneca</a> speaks diffusely on auroras in the first book of his <a href=\"/wiki/Naturales_Quaestiones\" title=\"Naturales Quaestiones\" class=\"mw-redirect\">Naturales Quaestiones</a>, drawing mainly from <a href=\"/wiki/Aristotle\" title=\"Aristotle\">Aristotle</a>; he classifies them (\"putei\" or wells when they are circular and \"rim a large hole in the sky\", \"pithaei\" when they look like casks, \"chasmata\" from the same root of the English chasm, \"pogoniae\" when they are bearded, \"cyparissae\" when they look like <a href=\"/wiki/Cypress\" title=\"Cypress\">cypresses</a>), describes their manifold colors and asks himself whether they are above or below the <a href=\"/wiki/Clouds\" title=\"Clouds\" class=\"mw-redirect\">clouds</a>. He recalls that under <a href=\"/wiki/Tiberius\" title=\"Tiberius\">Tiberius</a>, an aurora formed above <a href=\"/wiki/Ostia_Antica\" title=\"Ostia Antica\">Ostia</a>, so intense and so red that a cohort of the army, stationed nearby for fireman duty, galloped to the city.</li><li>Walter William Bryant wrote in his book <a href=\"//en.wikiquote.org/wiki/Kepler\" class=\"extiw\" title=\"q:Kepler\"><i>Kepler</i></a> (1920) that <a href=\"/wiki/Tycho_Brahe\" title=\"Tycho Brahe\">Tycho Brahe</a> \"seems to have been something of a <a href=\"/wiki/Homeopathy\" title=\"Homeopathy\">homœopathist</a>, for he recommends <a href=\"//en.wikipedia.org/wiki/Sulphur#History\" class=\"extiw\" title=\"w:Sulphur\">sulphur</a> to cure infectious diseases “brought on by the sulphurous vapours of the Aurora Borealis.\"<sup id=\"cite_ref-9\" class=\"reference\"></sup></li><li><a href=\"/wiki/Benjamin_Franklin\" title=\"Benjamin Franklin\">Benjamin Franklin</a> theorized that the \"mystery of the Northern Lights\" was caused by a concentration of electrical charges in the polar regions intensified by the snow and other moisture.<sup id=\"cite_ref-10\" class=\"reference\"></sup></li><li>Auroral electrons come from beams emitted by the Sun. This was claimed around 1900 by <a href=\"/wiki/Kristian_Birkeland\" title=\"Kristian Birkeland\">Kristian Birkeland</a>, whose experiments in a vacuum chamber with electron beams and magnetized spheres (miniature models of Earth or \"terrellas\") showed that such electrons would be guided toward the polar regions. Problems with this model included absence of aurora at the poles themselves, self-dispersal of such beams by their negative charge, and more recently, lack of any observational evidence in space.</li><li>The aurora is the overflow of the <a href=\"/wiki/Van_Allen_radiation_belt\" title=\"Van Allen radiation belt\">radiation belt</a> (\"leaky bucket theory\"). This was first disproved around 1962 by <a href=\"/wiki/James_Van_Allen\" title=\"James Van Allen\">James Van Allen</a> and co-workers, who showed that the high rate of energy dissipation by the aurora would quickly drain the radiation belt. Soon afterward, it became clear that most of the energy in trapped particles resided in positive ions, while auroral particles were almost always electrons, of relatively low energy.</li><li>The aurora is produced by <a href=\"/wiki/Solar_wind\" title=\"Solar wind\">solar wind</a> particles guided by Earth\'s field lines to the top of the atmosphere. This holds true for the cusp aurora, but outside the cusp, the solar wind has no direct access. In addition, the main energy in the solar wind resides in positive ions; electrons only have about 0.5 eV (electron volt), and while in the cusp this may be raised to 50–100 eV, that still falls short of auroral energies.</li></ul>";

        var auroralMechanismContent = "<p>Auroras result from emissions of <a href=\"/wiki/Photon\" title=\"Photon\">photons</a> in the Earth's upper <a href=\"/wiki/Earth%27s_atmosphere\" title=\"Earth's atmosphere\" class=\"mw-redirect\">atmosphere</a>, above 80&nbsp;km (50&nbsp;mi), from <a href=\"/wiki/Ionized\" title=\"Ionized\" class=\"mw-redirect\">ionized</a> <a href=\"/wiki/Nitrogen\" title=\"Nitrogen\">nitrogen</a> atoms regaining an electron, and <a href=\"/wiki/Oxygen\" title=\"Oxygen\">oxygen</a> and <a href=\"/wiki/Nitrogen\" title=\"Nitrogen\">nitrogen</a> atoms returning from an <a href=\"/wiki/Excited_state\" title=\"Excited state\">excited state</a> to <a href=\"/wiki/Ground_state\" title=\"Ground state\">ground state</a>.<sup id=\"cite_ref-11\" class=\"reference\"><a href=\"#cite_note-11\"><span>[</span>11<span>]</span></a></sup> They are ionized or <a href=\"/wiki/Excited_state\" title=\"Excited state\">excited</a> by the collision of <a href=\"/wiki/Solar_wind\" title=\"Solar wind\">solar wind</a> and <a href=\"/wiki/Magnetosphere\" title=\"Magnetosphere\">magnetospheric</a> particles being funneled down and accelerated along the Earth's magnetic field lines; excitation energy is lost by the emission of a photon, or by collision with another atom or molecule:</p><dl><dt><a href=\"/wiki/Oxygen\" title=\"Oxygen\">oxygen</a> emissions</dt><dd>green or brownish-red, depending on the amount of energy absorbed.</dd><dt><a href=\"/wiki/Nitrogen\" title=\"Nitrogen\">nitrogen</a> emissions</dt><dd>blue or red; blue if the atom regains an electron after it has been ionized, red if returning to <a href=\"/wiki/Ground_state\" title=\"Ground state\">ground state</a> from an <a href=\"/wiki/Excited_state\" title=\"Excited state\">excited state</a>.</dd></dl><p>Oxygen is unusual in terms of its return to <a href=\"/wiki/Ground_state\" title=\"Ground state\">ground state</a>: it can take three quarters of a second to emit green light and up to two minutes to emit red. Collisions with other atoms or molecules absorb the excitation energy and prevent emission. Because the very top of the atmosphere has a higher percentage of oxygen and is sparsely distributed such collisions are rare enough to allow time for oxygen to emit red. Collisions become more frequent progressing down into the atmosphere, so that red emissions do not have time to happen, and eventually even green light emissions are prevented.</p><p>This is why there is a color differential with altitude; at high altitude oxygen red dominates, then oxygen green and nitrogen blue/red, then finally nitrogen blue/red when collisions prevent oxygen from emitting anything. Green is the most common of all auroras. Behind it is pink, a mixture of light green and red, followed by pure red, yellow (a mixture of red and green), and lastly, pure blue.</p><p>Auroras are associated with the solar wind, a flow of ions continuously flowing outward from the Sun. The Earth's magnetic field traps these particles, many of which travel toward the poles where they are accelerated toward Earth. Collisions between these ions and atmospheric atoms and molecules cause energy releases in the form of auroras appearing in large circles around the poles. Auroras are more frequent and brighter during the intense phase of the solar cycle when <a href=\"/wiki/Coronal_mass_ejections\" title=\"Coronal mass ejections\" class=\"mw-redirect\">coronal mass ejections</a> increase the intensity of the solar wind.<sup id=\"cite_ref-12\" class=\"reference\"><a href=\"#cite_note-12\"><span>[</span>12<span>]</span></a></sup></p>";

        var solarWindAndTheMagnetosphereContent = "<p>The Earth is constantly immersed in the <a href=\"/wiki/Solar_wind\" title=\"Solar wind\">solar wind</a>, a rarefied flow of hot plasma (gas of free electrons and positive ions) emitted by the Sun in all directions, a result of the two-million-degree heat of the Sun's outermost layer, the <a href=\"/wiki/Corona\" title=\"Corona\">corona</a>. The solar wind usually reaches Earth with a velocity around 400&nbsp;km/s, density around 5 ions/cm<sup>3</sup> and magnetic field intensity around 2–5 nT (<a href=\"/wiki/Tesla_(unit)\" title=\"Tesla (unit)\">nanoteslas</a>; Earth's surface field is typically 30,000–50,000 nT). These are typical values. During <a href=\"/wiki/Geomagnetic_storm\" title=\"Geomagnetic storm\">magnetic storms</a>, in particular, flows can be several times faster; the <a href=\"/wiki/Interplanetary_magnetic_field\" title=\"Interplanetary magnetic field\">interplanetary magnetic field</a> (IMF) may also be much stronger.</p><p>The Earth is constantly immersed in the <a href=\"/wiki/Solar_wind\" title=\"Solar wind\">solar wind</a>, a rarefied flow of hot plasma (gas of free electrons and positive ions) emitted by the Sun in all directions, a result of the two-million-degree heat of the Sun's outermost layer, the <a href=\"/wiki/Corona\" title=\"Corona\">corona</a>. The solar wind usually reaches Earth with a velocity around 400&nbsp;km/s, density around 5 ions/cm<sup>3</sup> and magnetic field intensity around 2–5 nT (<a href=\"/wiki/Tesla_(unit)\" title=\"Tesla (unit)\">nanoteslas</a>; Earth's surface field is typically 30,000–50,000 nT). These are typical values. During <a href=\"/wiki/Geomagnetic_storm\" title=\"Geomagnetic storm\">magnetic storms</a>, in particular, flows can be several times faster; the <a href=\"/wiki/Interplanetary_magnetic_field\" title=\"Interplanetary magnetic field\">interplanetary magnetic field</a> (IMF) may also be much stronger.</p><p>The IMF originates on the Sun, related to the field of <a href=\"/wiki/Sunspot\" title=\"Sunspot\">sunspots</a>, and its <a href=\"/wiki/Magnetism\" title=\"Magnetism\">field lines (lines of force)</a> are dragged out by the solar wind. That alone would tend to line them up in the Sun-Earth direction, but the rotation of the Sun skews them (at Earth) by about 45 degrees, so that field lines passing Earth may actually start near the western edge (\"limb\") of the visible Sun.</p><p>The magnetosphere is full of trapped plasma as the solar wind passes the Earth. The flow of plasma into the magnetosphere increases with increases in solar wind density and speed, with increase in the southward component of the IMF and with increases in turbulence in the solar wind flow. The flow pattern of magnetospheric plasma is from the magnetotail toward the Earth, around the Earth and back into the solar wind through the <a href=\"/wiki/Magnetopause\" title=\"Magnetopause\">magnetopause</a> on the day-side. In addition to moving perpendicular to the Earth's magnetic field, some magnetospheric plasma travel down along the Earth's magnetic field lines and lose energy to the atmosphere in the auroral zones. Magnetospheric electrons accelerated downward by field-aligned electric fields cause the bright aurora features. The un-accelerated electrons and ions cause the dim glow of the diffuse aurora.</p>";

        var frequencyOfOccurrenceContent = "<p>Auroras are occasionally seen in temperate latitudes, when a magnetic storm temporarily enlarges the auroral oval. Large magnetic storms are most common during the peak of the eleven-year <a href=\"/wiki/Sunspot\" title=\"Sunspot\">sunspot cycle</a> or during the three years after that peak. Within the auroral zone the likelihood of an aurora occurring depends mostly on the slant of interplanetary magnetic field (IMF) lines (the slant is known as B<sub>z</sub>), however, being greater with southward slants.</p><p><a href=\"/wiki/Geomagnetic_storm\" title=\"Geomagnetic storm\">Geomagnetic storms</a> that ignite auroras actually happen more often during the months around the <a href=\"/wiki/Equinox\" title=\"Equinox\">equinoctes</a>. It is not well understood why geomagnetic storms are tied to Earth's seasons while polar activity is not. But it is known that during spring and autumn, the interplanetary magnetic field and that of Earth link up. At the <a href=\"/wiki/Magnetopause\" title=\"Magnetopause\">magnetopause</a>, Earth's magnetic field points north. When B<sub>z</sub> becomes large and negative (i.e., the IMF tilts south), it can partially cancel Earth's magnetic field at the point of contact. South-pointing B<sub>z</sub>s open a door through which energy from the solar wind reaches Earth's inner magnetosphere.</p><p>The peaking of B<sub>z</sub> during this time is a result of geometry. The IMF comes from the Sun and is carried outward with the solar wind. The rotation of the Sun causes the IMF to have a <a href=\"/wiki/Parker_spiral\" title=\"Parker spiral\" class=\"mw-redirect\">spiral shape</a> called the Parker spiral. The southward (and northward) excursions of B<sub>z</sub> are greatest during April and October, when Earth's magnetic dipole axis is most closely aligned with the Parker spiral.</p><p>B<sub>z</sub> is not the only influence on geomagnetic activity, however, the Sun's rotation axis is tilted 8 degrees with respect to the plane of Earth's orbit. The solar wind blows more rapidly from the Sun's poles than from its equator, thus the average speed of particles buffeting Earth's magnetosphere waxes and wanes every six months. The solar wind speed is greatest – by about 50&nbsp;km/s, on average – around 5 September and 5 March when Earth lies at its highest heliographic latitude.</p><p>Still, neither B<sub>z</sub> nor the solar wind can fully explain the seasonal behavior of geomagnetic storms. Those factors together contribute only about one-third of the observed semiannual variations.</p>";

        // These three strings encode placeholder images. You will want to set the
        // backgroundImage property in your real data to be URLs to images.
        var historyOfAuroraTheoriesImage = "http://upload.wikimedia.org/wikipedia/en/thumb/4/4d/Aurora_Borealis_Poster.jpg/570px-Aurora_Borealis_Poster.jpg";
        var auroralMechanismImage = "http://upload.wikimedia.org/wikipedia/commons/6/63/Aurora_australis_panorama.jpg";
        var solarWindAndTheMagnetosphereImage = "http://upload.wikimedia.org/wikipedia/commons/d/d9/Calgary-Northern_ligths.JPG";
        var frequencyOfOccurrenceImage = "http://upload.wikimedia.org/wikipedia/commons/9/9a/Aurora_australis_20050911.jpg";
        // Each of these sample groups must have a unique key to be displayed
        // separately.
        var sampleGroups = [
            { key: "History-of-aurora-theories", title: "History of aurora theories", subtitle: "Multiple superstitions and obsolete theories", backgroundImage: historyOfAuroraTheoriesImage, description: groupDescription },
            { key: "Auroral mechanism", title: "Auroral mechanism", subtitle: "Auroras result from emissions of photons in the Earth's upper atmosphere", backgroundImage: auroralMechanismImage, description: groupDescription },
            { key: "Forms-and-magnetism", title: "Forms and magnetism", subtitle: "Typically the aurora appears either as a diffuse glow", backgroundImage: solarWindAndTheMagnetosphereImage, description: groupDescription },
            { key: "Solar-wind-and-the-magnetosphere", title: "Solar wind and the magnetosphere", subtitle: "The Earth is constantly immersed in the solar wind", backgroundImage: frequencyOfOccurrenceImage, description: groupDescription }
        ];

        // Each of these sample items should have a reference to a particular
        // group.
        var sampleItems = [
            { group: sampleGroups[0], title: "History of aurora theories", subtitle: "Multiple superstitions and obsolete theories", description: itemDescription, content: historyOfAuroraTheoriesContent, backgroundImage: historyOfAuroraTheoriesImage },
            { group: sampleGroups[1], title: "Auroral mechanism", subtitle: "Auroras result from emissions of photons in the Earth's upper atmosphere", description: itemDescription, content: auroralMechanismContent, backgroundImage: auroralMechanismImage },
            { group: sampleGroups[2], title: "Forms and magnetism", subtitle: "Typically the aurora appears either as a diffuse glow", description: itemDescription, content: solarWindAndTheMagnetosphereContent, backgroundImage: solarWindAndTheMagnetosphereImage },
            { group: sampleGroups[3], title: "Solar wind and the magnetosphere", subtitle: "The Earth is constantly immersed in the solar wind", description: itemDescription, content: frequencyOfOccurrenceContent, backgroundImage: frequencyOfOccurrenceImage },
        ];

        return sampleItems;
    }
})();