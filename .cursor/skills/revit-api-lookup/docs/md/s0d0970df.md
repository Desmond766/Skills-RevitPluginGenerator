---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetApplicationGUID(System.Guid)
source: html/c94ecbf6-126b-60e6-cff1-42fb93e85c81.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetApplicationGUID Method

Sets the GUID of the application or add-in that may access entities of this Schema under
 the Application acess level.

## Syntax (C#)
```csharp
public SchemaBuilder SetApplicationGUID(
	Guid applicationGUID
)
```

## Parameters
- **applicationGUID** (`System.Guid`) - The application id.

## Returns
The SchemaBuilder object may be used to add more settings.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

