namespace CodeWF.Core.Test;

[TestClass]
public class TranslationServiceUnitTest
{
	private readonly ITranslationService _translationService = new TranslationService();

	[TestMethod]
	public async Task Test_ChineseToEnglishAsync_SUCCESS()
	{
		const string chineseText = "��繤��";

		var englishText = await _translationService.ChineseToEnglishAsync(chineseText);

		Assert.AreEqual(englishText, "Code World Workshop");
	}

	[TestMethod]
	public async Task Test_EnglishToChineseAsync_SUCCESS()
	{
		const string englishText = "Code World Workshop";

		var chineseText = await _translationService.EnglishToChineseAsync(englishText);

		Assert.AreEqual(chineseText, "�������繤����");
	}

	[TestMethod]
	public void Test_EnglishToSlug_SUCCESS()
	{
		const string englishText = "Code World Workshop";

		var urlSlug = _translationService.EnglishToUrlSlug(englishText);

		Assert.AreEqual(urlSlug, "code-world-workshop");
	}

	[TestMethod]
	public async Task Test_ChineseToSlugAsync_SUCCESS()
	{
		const string chineseText = "��繤��";

		var englishText = await _translationService.ChineseToEnglishAsync(chineseText);

		var urlSlug = _translationService.EnglishToUrlSlug(englishText);

		Assert.AreEqual(urlSlug, "code-world-workshop");
	}
}