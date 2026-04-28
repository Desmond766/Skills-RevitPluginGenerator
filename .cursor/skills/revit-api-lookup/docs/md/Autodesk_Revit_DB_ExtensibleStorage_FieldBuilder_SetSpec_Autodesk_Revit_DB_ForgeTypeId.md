---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.SetSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/d801562b-ca4b-740f-07ed-7aa2ac336174.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.SetSpec Method

Sets the spec describing the field's values.

## Syntax (C#)
```csharp
public FieldBuilder SetSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec.

## Returns
The FieldBuilder object may be used to add more details to the field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.
 -or-
 The field type does not utilize unit conversions.

