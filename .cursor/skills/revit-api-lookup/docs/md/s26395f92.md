---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationPartSizeMap.#ctor(System.String,System.Double,System.Double,System.Boolean,Autodesk.Revit.DB.ConnectorProfileType,System.Int32,System.Int32)
source: html/009a1eb1-2ef8-3af0-a956-8ee5e8e46dd5.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationPartSizeMap.#ctor Method

Creates a new instance of the FabricationPartSizeMap class.

## Syntax (C#)
```csharp
public FabricationPartSizeMap(
	string size,
	double widthDiameter,
	double depth,
	bool isProductList,
	ConnectorProfileType profileType,
	int serviceId,
	int paletteId
)
```

## Parameters
- **size** (`System.String`) - The size display string for the straight that can be used by the user interface.
- **widthDiameter** (`System.Double`) - The width or diameter of the straight.
- **depth** (`System.Double`) - The depth of the straight.
- **isProductList** (`System.Boolean`) - Set if the straight a product list or not.
- **profileType** (`Autodesk.Revit.DB.ConnectorProfileType`) - Set the shape of the straight.
- **serviceId** (`System.Int32`) - Set the service identifier of the straight.
- **paletteId** (`System.Int32`) - Set the palette identifier of the straight.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

