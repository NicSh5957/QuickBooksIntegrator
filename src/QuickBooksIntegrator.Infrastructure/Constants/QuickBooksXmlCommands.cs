namespace QuickBooksIntegrator.Infrastructure.Constants;

//TODO [11.19.2024] [NicSh] [Данные константы лучше вынести в отдельный файл. Будет удобнее передавать без перекомпиляции. либо продумать механизм генерации XML(Builder)]
public static class QuickBooksXmlCommands
{
    public const string GetCompanyData = @"<?qbxml version=""8.0""?>
                                            <QBXML>
                                                <QBXMLMsgsRq onError=""stopOnError"">
                                                    <CompanyQueryRq requestID=""1"" />
                                                </QBXMLMsgsRq>
                                            </QBXML>";

    public const string GetInvoiceData = @"<?qbxml version=""8.0""?>
                                            <QBXML>
                                                <QBXMLMsgsRq onError=""stopOnError"">
                                                    <InvoiceQueryRq requestID=""2"" />
                                                </QBXMLMsgsRq>
                                            </QBXML>";

    public const string GetItemSalesData = @"<?qbxml version=""8.0""?>
                                            <QBXML>
                                                <QBXMLMsgsRq onError=""stopOnError"">
                                                    <ItemSalesTaxQueryRq requestID=""3"" />
                                                </QBXMLMsgsRq>
                                            </QBXML>";

    public const string GetBillData = @"<?qbxml version=""8.0""?>
                                        <QBXML>
                                            <QBXMLMsgsRq onError=""stopOnError"">
                                                <BillQueryRq requestID=""4"" />
                                            </QBXMLMsgsRq>
                                        </QBXML>";

    public const string GetCheckData = @"<?qbxml version=""8.0""?>
                                        <QBXML>
                                            <QBXMLMsgsRq onError=""stopOnError"">
                                                <CheckQueryRq requestID=""5"" />
                                            </QBXMLMsgsRq>
                                        </QBXML>";

    public const string AddInvoiceData = @"<?qbxml version=""8.0""?>
                                        <QBXML>
                                            <QBXMLMsgsRq onError=""stopOnError"">
                                                <InvoiceAddRq>
                                                    <InvoiceAdd>
                                                        <CustomerRef>
                                                            <FullName>{0}</FullName>
                                                        </CustomerRef>
                                                        <TxnDate>{1}</TxnDate>
                                                        <InvoiceLineAdd>
                                                            <Quantity>{3}</Quantity>
                                                            <Rate>{4}</Rate>
                                                        </InvoiceLineAdd>
                                                    </InvoiceAdd>
                                                </InvoiceAddRq>
                                            </QBXMLMsgsRq>
                                        </QBXML>";
}