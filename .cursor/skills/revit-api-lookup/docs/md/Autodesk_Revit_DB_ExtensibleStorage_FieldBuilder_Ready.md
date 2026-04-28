---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.Ready
source: html/f137ea2f-b359-b285-331b-1eb72447015a.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.Ready Method

Checks whether the builder may be used.

## Syntax (C#)
```csharp
public bool Ready()
```

## Returns
True if the SchemaBuilder has not yet been finished.

## Remarks
All newly constructed FieldBuilders are usable until the call to the Finish method
 of the constructing SchemaBuilder.

