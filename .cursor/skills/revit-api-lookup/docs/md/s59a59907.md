---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.GetNumberingSchema(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.NumberingSchemaType)
source: html/fb3e529c-bccd-40fb-c24d-c5de5296edea.htm
---
# Autodesk.Revit.DB.NumberingSchema.GetNumberingSchema Method

Returns an instance of the specified Numbering Schema in the given document.

## Syntax (C#)
```csharp
public static NumberingSchema GetNumberingSchema(
	Document document,
	NumberingSchemaType schemaType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A document to get the numbering schema from.
- **schemaType** (`Autodesk.Revit.DB.NumberingSchemaType`) - The type of a built-in schema to get.

## Returns
Instance of the specified schema.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given schemaType has an invalid Id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

