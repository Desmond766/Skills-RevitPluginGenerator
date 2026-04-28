---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetDocumentation(System.String)
source: html/e712e079-d5fe-fcbb-ab78-90e8608a82a4.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetDocumentation Method

Sets the documentation string for the Schema.

## Syntax (C#)
```csharp
public SchemaBuilder SetDocumentation(
	string documentation
)
```

## Parameters
- **documentation** (`System.String`) - The documentation string.

## Returns
The SchemaBuilder object may be used to add more settings.

## Remarks
While Entities may be hidden using access levels, Schemas and Fields are visible to
 clients and other developers. In the interest of clarity and interoperability, you are
 very strongly encouraged to provide good documentation with your Schemas.
Explain the intent of the data and how it is meant to be interpreted. It is not
 useful to repeat information that can be observed directly (e.g. types and units).
Note that documentation, like all other contents of Schemas and Fields is immutable
 once the add-in using the Schema is published.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

