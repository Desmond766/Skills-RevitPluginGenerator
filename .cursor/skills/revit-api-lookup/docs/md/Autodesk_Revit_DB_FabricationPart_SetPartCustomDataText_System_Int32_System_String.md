---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SetPartCustomDataText(System.Int32,System.String)
source: html/8b64c872-2291-71f6-ffc4-0ba6ab01472f.htm
---
# Autodesk.Revit.DB.FabricationPart.SetPartCustomDataText Method

Set the custom data real value for the specified custom data.

## Syntax (C#)
```csharp
public void SetPartCustomDataText(
	int customId,
	string value
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to set.
- **value** (`System.String`) - The text value of the custom data. If the data is not a text type the value will be parsed according to the fabrication confifuration rules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

