An ASCOM Switch driver for the West Mountain Radio RIGRunner 4005i.

This driver allows RR4005i ports to be turned on or off by ASCOM clients that utilizae the Switch interface.

Requires V 1.15 of the RR4005i Firmware.

---------------------------------

Notes :

	* The "Fetch port names on connect" checkbox on the driver setup screen allows you to retrieve the port names from the RIGRunner
		the first time you connect to it.  After this, the port names will be stored in the ASCOM profile for the driver, and this
		fetch will no longer be required, unless you re-install the driver or change port names.  While not necessary, you may
		leave this checked with no harm other than a very minor performance hit upon connecting.
		
	* The driver treats all ports as "boolean switches", switches that only have 2 states, On or Off.  ASCOM, however, allows clients
		to set switch "values" within a range specified by the driver, and allows fractional values.  The range of all ports on the
		RIGRunner is 0 (off) to 1 (on).  Any attempt to set a switch to a value below 0.5 results in turning the switch off, any attempt
		to set a value equal to or above 0.5 results in turning the switch on.