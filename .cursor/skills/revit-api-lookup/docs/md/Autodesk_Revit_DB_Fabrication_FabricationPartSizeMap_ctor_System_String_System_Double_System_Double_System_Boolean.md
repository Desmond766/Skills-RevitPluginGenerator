---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationPartSizeMap.#ctor(System.String,System.Double,System.Double,System.Boolean)
source: html/82fb5b33-008d-586a-8750-4a78864d7939.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationPartSizeMap.#ctor Method

Creates a new instance of the FabricationPartSizeMap class.

## Syntax (C#)
```csharp
public FabricationPartSizeMap(
	string size,
	double widthDiameter,
	double depth,
	bool isProductList
)
```

## Parameters
- **size** (`System.String`) - The size display string for the straight that can be used by the user interface.
- **widthDiameter** (`System.Double`) - The width or diameter of the straight.
- **depth** (`System.Double`) - The depth of the straight.
- **isProductList** (`System.Boolean`) - Set if the straight a product list or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

