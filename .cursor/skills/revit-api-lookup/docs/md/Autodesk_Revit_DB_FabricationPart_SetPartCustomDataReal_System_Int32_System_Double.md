---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SetPartCustomDataReal(System.Int32,System.Double)
source: html/2f712219-70a9-76f0-6f10-36ea98f72a14.htm
---
# Autodesk.Revit.DB.FabricationPart.SetPartCustomDataReal Method

Set the custom data real value for the specified custom data.

## Syntax (C#)
```csharp
public void SetPartCustomDataReal(
	int customId,
	double value
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to set.
- **value** (`System.Double`) - The real value of the custom data. If the data is not a real type the value will be parsed according to the fabrication confifuration rules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.

