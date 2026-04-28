---
kind: type
id: T:Autodesk.Revit.DB.IDuplicateTypeNamesHandler
source: html/2fa855ba-6a1a-b0af-8079-10415ff7e2d3.htm
---
# Autodesk.Revit.DB.IDuplicateTypeNamesHandler

An interface for custom handlers of duplicate type names encountered during a paste operation. When the destination document
 contains types that have the same names as the types being copied, but different internals, a decision must be made on how to proceed - whether to
 cancel the operation or continue, but only copy types with unique names.

## Syntax (C#)
```csharp
public interface IDuplicateTypeNamesHandler
```

