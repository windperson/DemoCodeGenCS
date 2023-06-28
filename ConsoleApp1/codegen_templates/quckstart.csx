// Multiple-files output, with programmatic approach
public class MyTemplate
{
    void Main(ICodegenContext context)
    {
        var model = new { Tables = new string[] { "Users", "Products" } };
        foreach (var table in model.Tables)
            context[table + ".cs"]
                .WriteLine("//" + table)
                .WriteLine(GenerateTable(table));
    }
    FormattableString GenerateTable(string tableName)
    {
        return $$"""
            namespace MyNamespace
            {
                public class {{tableName}}
                {
                    // my properties...
                }
            }
            """;
    }
}